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
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        public UserAccountService(ApplicationDbContext context, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public Task<List<ApplicationUserDTO>> GetAllUserAccountsAsync()
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
                    ConfirmPassword = u.RealPassword,

                })
                .ToListAsync();
            return accounts;   
        }
        public Task<ApplicationUserDTO?> GetUserAccByIdAsync(string id)
        {
            throw new NotImplementedException();
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
                RealPassword = account.ConfirmPassword
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
                ConfirmPassword = newUser.RealPassword
            });
        }
        //public Task<ApplicationUserDTO> EditBankAcc(int id, ApplicationUserDTO account)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<bool> DeleteUserAccAsync(string id)
        {
            var user = _context.Users.Where(u => u.Id == id);

            if (user == null || !user.Any())
            {
                return false; // User not found
            }
            _context.Users.Remove(user.First());
            await _context.SaveChangesAsync();
            return true; // User deleted successfully
            
        }
    }
}
