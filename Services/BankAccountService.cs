using DailyBalance1._0.Data;
using DailyBalance1._0.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DailyBalance1._0.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly ApplicationDbContext _context;

        public BankAccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BankAccountDTO>> GetAllAccountsAsync()
        {
            return await _context.BankAccounts
                .Select(b => new BankAccountDTO
                {
                    BankAccountId = b.BankAccountId,
                    BankAccountName = b.BankAccountName,
                    BankAccountBalance = b.BankAccountBalance
                })
                .ToListAsync();
        }

        public async Task<BankAccountDTO?> GetAccountByIdAsync(int id)
        {
            var account = await _context.BankAccounts.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            return new BankAccountDTO
            {
                BankAccountId = account.BankAccountId,
                BankAccountName = account.BankAccountName,
                BankAccountBalance = account.BankAccountBalance
            };
        }

        
    }
}
