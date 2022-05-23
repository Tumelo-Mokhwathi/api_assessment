using api_assessment.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_assessment.Services.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyList<User>> GetAsync();
        Task<IReadOnlyList<User>> CreateAsync(User user);
        Task<Result<User>> UpdateAsync(int id, User user);
        Task<Result<User>> DeleteAsync(int id);
    }
}
