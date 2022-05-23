using api_assessment.Response;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_assessment.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Error(Result result, string source)
            => ActionResponse.Error(
                System.Net.HttpStatusCode.InternalServerError,
                result.Error,
                source);

        protected IActionResult Ok(object result, string source)
                    => ActionResponse.Success(System.Net.HttpStatusCode.OK, result, source);

        protected IActionResult OkOrError(Result result, string source)
            => result.IsSuccess ? Ok(source) : Error(result, source);

        protected IActionResult OkOrError<T>(Result<T> result, string source)
            => result.IsSuccess ? Ok(result.Value, source) : Error(result, source);
    }
}
