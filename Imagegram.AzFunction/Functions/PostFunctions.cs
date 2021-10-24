using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Imagegram.Application.Interfaces;
using Imagegram.AzFunction.Extensions;
using Imagegram.Application.DTOs;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Imagegram.Application.DTOs.Post;
using Imagegram.Application.DTOs.ImgramUser;
using Microsoft.Extensions.Primitives;
using Imagegram.Application.Contracts.Infrastructure;
using Imagegram.Application.Models;

namespace Imagegram.AzFunction.Functions
{
    public class PostFunctions
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IImageUploader _imageUploader;

        public PostFunctions(IPostService postService, IUserService userService, IImageUploader imageUploader)
        {
            _postService = postService;
            _userService = userService;
            _imageUploader = imageUploader;
        }

        [FunctionName("createpost")]
        public async Task<IActionResult> CreatePost(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                IFormCollection formdata = await req.ReadFormAsync();
                IFormFile file = req.Form.Files["image"];
                StringValues postData = req.Form["data"];

                var postDto = JsonConvert.DeserializeObject<PostDto>(postData);
                var validations = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(postDto, new ValidationContext(postDto, null, null), validations, true);

                if (!isValid)
                    return new BadRequestObjectResult($"Model is invalid: {string.Join(", ", validations.Select(s => s.ErrorMessage).ToArray())}");

                // TODO: Call service for uploading
                Stream fileStream = file.OpenReadStream();

                var fileDetail = new ImageFileDetail();
                fileDetail.FileName = file.FileName;
                fileDetail.ContentType = file.ContentType;
                fileDetail.SourceIp = req.Headers.FirstOrDefault(x => x.Key == "X-Forwarded-For").Value.FirstOrDefault();
                fileDetail.FileStream = fileStream;
                postDto.ImgPath = await _imageUploader.UploadImage(fileDetail);

                //postDto.User = await GetUser(postDto.ImgramUserId);
                int CreatedId = await _postService.Create(postDto);

                return new OkObjectResult($"Successfully created post with id {CreatedId}");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("getposts")]
        public async Task<IActionResult> GetPost(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request to get users.");

            var posts = await _postService.GetAll();

            return new OkObjectResult(posts);
        }

        [FunctionName("getpostsorderbycommentcount")]
        public async Task<IActionResult> GetPostsOrderByCommenCount(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request to get users.");

            var posts = await _postService.GetAllOrderByComments();

            return new OkObjectResult(posts);
        }

        private async Task<ImgramUserDto> GetUser(int userId)
        {
            var userDto = await _userService.Get(userId);

            if (userDto is null)
                throw new Exception($"User with id {userId} was not found.");

            return userDto;
        }
    }
}
