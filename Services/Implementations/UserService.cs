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
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<User>> GetAsync() =>
            await _context.Users
            .Select(m => new User
            {
                ID = m.ID,
                FriendlyName = m.FriendlyName,
                DateOfBirth = m.DateOfBirth,
                ContactNumber = m.ContactNumber,
                Email = m.Email,
                Company = m.Company,
                CanLogin = m.CanLogin
            })
            .ToListAsync()
            .ConfigureAwait(false);

        public async Task<IReadOnlyList<User>> CreateAsync(User user)
        {
            Random rnd = new Random();
            int uniqueId = rnd.Next(1, 1000);

            var model = new User()
            {
                ID = uniqueId,
                FriendlyName = user.FriendlyName,
                DateOfBirth = user.DateOfBirth,
                ContactNumber = user.ContactNumber,
                Email = user.Email,
                Company = user.Company,
                CanLogin = user.CanLogin
            };

            _context.Add(model);
            await _context.SaveChangesAsync();

            var newList = await _context.Users
            .Select(m => new User
            {
                ID = m.ID,
                FriendlyName = m.FriendlyName,
                DateOfBirth = m.DateOfBirth,
                ContactNumber = m.ContactNumber,
                Email = m.Email,
                Company = m.Company,
                CanLogin = m.CanLogin
            })
            .ToListAsync()
            .ConfigureAwait(false);

            return newList;
        }
        public async Task<Result<User>> UpdateAsync(int id, User user)
        {
            var model = await _context.Users.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<User>($"User not found for ID {id}");
            }

            model.FriendlyName = user.FriendlyName;
            model.DateOfBirth = user.DateOfBirth;
            model.ContactNumber = user.ContactNumber;
            model.Email = user.Email;
            model.Company = user.Company;
            model.CanLogin = user.CanLogin;

            _context.Update(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<User>> DeleteAsync(int id)
        {
            var model = await _context.Users.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<User>($"User not found for ID {id}");
            }

            _context.Remove(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
    }
}
