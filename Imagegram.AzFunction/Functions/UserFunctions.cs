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
using Imagegram.Application.DTOs.ImgramUser;

namespace Imagegram.AzFunction.Functions
{
    public class UserFunctions
    {
        private readonly IUserService _userService;

        public UserFunctions(IUserService userService)
        {
            _userService = userService;
        }

        [FunctionName("createUser")]
        public async Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request to create user.");

            try
            {
                HttpResponseBody<ImgramUserDto> requestBody = await req.GetBodyAsync<ImgramUserDto>();

                if (!requestBody.IsValid)
                    return new BadRequestObjectResult($"Model is invalid: {string.Join(", ", requestBody.ValidationResults.Select(s => s.ErrorMessage).ToArray())}");

                ImgramUserDto userDto = requestBody.Value;

                await _userService.Create(userDto);

                return new OkObjectResult($"User has been created!");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("getusers")]
        public async Task<IActionResult> GetUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request to get users.");

            var users = await _userService.GetAll();

            return new OkObjectResult(users);
        }
    }
}
