﻿using DailyBalance1._0.DTOs;

namespace DailyBalance1._0.Services
{
    public interface IUserAccountService
    {
        Task<List<ApplicationUserDTO>> GetAllBankAccountsAsync();
        Task<ApplicationUserDTO?> GetUserAccByIdAsync(string id);
        Task<ApplicationUserDTO> CreateUserAccAsync(ApplicationUserDTO account);
        Task<ApplicationUserDTO> EditUserAcc(string id, ApplicationUserDTO account);
        Task<bool> DeleteUserAccAsync(string id);
    }
}
