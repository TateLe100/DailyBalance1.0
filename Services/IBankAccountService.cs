using DailyBalance1._0.DTOs;

namespace DailyBalance1._0.Services
{
    public interface IBankAccountService
    {
        Task<List<BankAccountDTO>> GetAllBankAccountsAsync();
        Task<BankAccountDTO?> GetBankAccByIdAsync(int id);
        Task<BankAccountDTO> CreateBankAccAsync(BankAccountDTO account);
        Task<BankAccountDTO> EditBankAcc(int id, BankAccountDTO account);
        Task<bool> DeleteBankAccAsync(int id);

    }
}
