using api_assessment.Models;
using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_assessment.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IReadOnlyList<Company>> GetAsync();
        Task<Result<Company>> CreateAsync(Company company);
        Task<Result<Company>> UpdateAsync(int id, Company company);
        Task<Result<Company>> DeleteAsync(int id);
    }
}
