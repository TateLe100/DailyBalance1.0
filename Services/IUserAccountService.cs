using DailyBalance1._0.DTOs;

namespace DailyBalance1._0.Services
{
    public interface IUserAccountService
    {
        Task<List<ApplicationUserDTO>> GetAllBankAccountsAsync();
        //Task<ApplicationUserDTO?> GetBankAccByIdAsync(int id);
        Task<ApplicationUserDTO> CreateUserAccAsync(ApplicationUserDTO account);
        //Task<ApplicationUserDTO> EditBankAcc(int id, ApplicationUserDTO account);
        //Task<bool> DeleteBankAccAsync(int id);
    }
}
