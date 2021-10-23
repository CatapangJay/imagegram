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

namespace Imagegram.AzFunction.Functions
{
    public class UserFunctions
    {
        private readonly IUserService _userService;

        public UserFunctions(IUserService userService)
        {
            _userService = userService;
        }

        [FunctionName("users")]
        public async Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userDto = JsonConvert.DeserializeObject<ImgramUserDto>(requestBody);

             await _userService.Create(userDto);

            return new OkObjectResult($"User has been created!");
        }

        [FunctionName("users")]
        public async Task<IActionResult> GetUser(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var userDto = JsonConvert.DeserializeObject<ImgramUserDto>(requestBody);

             await _userService.Create(userDto);

            return new OkObjectResult($"User has been created!");
        }
    }
}
