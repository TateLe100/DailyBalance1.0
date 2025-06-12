using DailyBalance1._0.Data;
using DailyBalance1._0.DTOs;
using DailyBalance1._0.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DailyBalance1._0.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly ApplicationDbContext _context;
        public UserAccountService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<List<ApplicationUserDTO>> GetAllBankAccountsAsync()
        {
            var accounts = _context.Users
                .Select(u => new ApplicationUserDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    RealPassword = u.RealPassword,

                })
                .ToListAsync();
            return accounts;   
        }
        public Task<ApplicationUserDTO?> GetUserAccByIdAsync(string id)
        {
            var user = _context.Users.Where(u => u.Id == id)
                .Select(u => new ApplicationUserDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    RealPassword = u.RealPassword,
                })
                .FirstOrDefaultAsync();
            return user;
        }
        public Task<ApplicationUserDTO> CreateUserAccAsync(ApplicationUserDTO account)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var newUser = new ApplicationUser
            {
                UserName = account.UserName,
                Email = account.Email,
                FirstName = account.FirstName,
                LastName = account.LastName,
                PhoneNumber = account.PhoneNumber,
                RealPassword = account.ConfirmPassword,
                PhoneNumberConfirmed = true
            };
            string hashedPassword = hasher.HashPassword(newUser, newUser.RealPassword);
            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Task.FromResult(new ApplicationUserDTO
            {
                Id = newUser.Id,
                UserName = newUser.UserName,
                Email = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                PhoneNumber = newUser.PhoneNumber,
                ConfirmPassword = newUser.RealPassword,
                Password = newUser.RealPassword
            });
        }
        public async Task<ApplicationUserDTO> EditUserAcc(string id, ApplicationUserDTO account)
        {
            var oldAcc = _context.Users.FirstOrDefault(x  => x.Id == id);

            // I have a validation in the controller so I technically dont need this but its fine for now 
            if (oldAcc == null)
            {
                return new ApplicationUserDTO();
            }

            oldAcc.UserName = account.UserName;
            oldAcc.Email = account.Email;
            oldAcc.FirstName = account.FirstName;
            oldAcc.LastName = account.LastName;
            oldAcc.PhoneNumber = account.PhoneNumber;
            oldAcc.RealPassword = account.RealPassword;
            oldAcc.Email = account.Email;
            _context.Users.Update(oldAcc);
            await _context.SaveChangesAsync();
            return new ApplicationUserDTO
            {
                Id = oldAcc.Id,
                UserName = oldAcc.UserName,
                Email = oldAcc.Email,
                FirstName = oldAcc.FirstName,
                LastName = oldAcc.LastName,
                PhoneNumber = oldAcc.PhoneNumber,
                ConfirmPassword = oldAcc.RealPassword,
                Password = oldAcc.RealPassword
            };
        }
        public Task<bool> DeleteUserAccAsync(string id)
        {
            var oldUser = _context.Users.Find(id);
            if (oldUser == null)
            {
                return Task.FromResult(false);
            }

            _context.Users.Remove(oldUser);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
