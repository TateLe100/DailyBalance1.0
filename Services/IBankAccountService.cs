using DailyBalance1._0.DTOs;

namespace DailyBalance1._0.Services
{
    public interface IBankAccountService
    {
        Task<List<BankAccountDTO>> GetAllAccountsAsync();
        Task<BankAccountDTO?> GetAccountByIdAsync(int id);
        Task<BankAccountDTO> CreateAccountAsync(BankAccountDTO account);
        Task<bool> DeleteAccountAsync(int id);
    }
}
