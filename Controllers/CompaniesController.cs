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
    public class CompaniesController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            ActionResponse.Success(HttpStatusCode.OK, await _companyService.GetAsync().ConfigureAwait(false), "get");


        [HttpPost]
        public async Task<IActionResult> Create(Company company) =>
            OkOrError(await _companyService.CreateAsync(company).ConfigureAwait(false), "create");


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Company company) =>
            OkOrError(await _companyService.UpdateAsync(id, company).ConfigureAwait(false), "update");


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            OkOrError(await _companyService.DeleteAsync(id).ConfigureAwait(false), "delete");
    }
}
