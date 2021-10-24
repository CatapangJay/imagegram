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
using Imagegram.Application.DTOs;
using Imagegram.AzFunction.Extensions;
using System.Linq;
using Imagegram.Application.DTOs.Comment;

namespace Imagegram.AzFunction.Functions
{
    public class CommentFunctions
    {
        private readonly ICommentService _commentService;

        public CommentFunctions(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [FunctionName("addcomment")]
        public async Task<IActionResult> AddComment(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request to create user.");

            try
            {
                HttpResponseBody<CommentDto> requestBody = await req.GetBodyAsync<CommentDto>();

                if (!requestBody.IsValid)
                    return new BadRequestObjectResult($"Model is invalid: {string.Join(", ", requestBody.ValidationResults.Select(s => s.ErrorMessage).ToArray())}");

                CommentDto userDto = requestBody.Value;

                await _commentService.AddComment(userDto);

                return new OkObjectResult($"Comment has been added!");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("getcomments")]
        public async Task<IActionResult> GetComments(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request to get users.");

            var users = await _commentService.GetAll();

            return new OkObjectResult(users);
        }
    }
}
