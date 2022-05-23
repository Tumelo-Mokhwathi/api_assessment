using api_assessment.Models;
using api_assessment.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_assessment.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Company>> GetAsync() =>
            await _context.Companies.Select(m => new Company
            {
                ID = m.ID,
                Name = m.Name,
                ContactNumber = m.ContactNumber,
                RegistrationNumber = m.RegistrationNumber,
                Active = m.Active
            })
            .ToListAsync()
            .ConfigureAwait(false);

        public async Task<Result<Company>> CreateAsync(Company company)
        {
            Random rnd = new Random();
            int uniqueId = rnd.Next(1, 1000);

            var model = new Company()
            {
                ID = uniqueId,
                Name = company.Name,
                ContactNumber = company.ContactNumber,
                RegistrationNumber = company.RegistrationNumber,
                Active = company.Active
            };

            _context.Add(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<Company>> UpdateAsync(int id, Company company)
        {
            var model = await _context.Companies.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<Company>($"Company not found for ID {id}");
            }

            model.Name = company.Name;
            model.Name = company.Name;
            model.ContactNumber = company.ContactNumber;
            model.RegistrationNumber = company.RegistrationNumber;
            model.Active = company.Active;

            _context.Update(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<Company>> DeleteAsync(int id)
        {
            var model = await _context.Companies.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<Company>($"Company not found for ID {id}");
            }

            _context.Remove(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
    }
}
