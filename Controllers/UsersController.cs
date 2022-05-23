using api_assessment.Models;
using api_assessment.Response;
using api_assessment.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api_assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            ActionResponse.Success(HttpStatusCode.OK, await _userService.GetAsync().ConfigureAwait(false), "get");


        [HttpPost]
        public async Task<IActionResult> Create(User user) =>
            ActionResponse.Success(HttpStatusCode.OK, await _userService.CreateAsync(user).ConfigureAwait(false), "create");


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, User user) =>
            OkOrError(await _userService.UpdateAsync(id, user).ConfigureAwait(false), "update");


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            OkOrError(await _userService.DeleteAsync(id).ConfigureAwait(false), "delete");
    }
}
