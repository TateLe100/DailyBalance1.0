using DailyBalance1._0.Data;
using DailyBalance1._0.DTOs;
using DailyBalance1._0.Models;
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

        public async Task<List<BankAccountDTO>> GetAllBankAccountsAsync()
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

        public async Task<BankAccountDTO?> GetBankAccByIdAsync(int id)
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

        public Task<BankAccountDTO> CreateBankAccAsync(BankAccountDTO account)
        {
            var newAccount = new BankAccount
            {
                BankAccountName = account.BankAccountName,
                BankAccountBalance = account.BankAccountBalance,
                CreationDate = DateTime.Now,
                UserId = "1" // Hardcoded for now
            };
            _context.BankAccounts.Add(newAccount);
            _context.SaveChanges();
            return Task.FromResult(new BankAccountDTO
            {
                BankAccountId = newAccount.BankAccountId,
                BankAccountName = newAccount.BankAccountName,
                BankAccountBalance = newAccount.BankAccountBalance
            });
        }


        public Task<BankAccountDTO> EditBankAcc(int id, BankAccountDTO account)
        {
            var bankAccount = _context.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return Task.FromResult(new BankAccountDTO());
            }
            bankAccount.BankAccountName = account.BankAccountName;
            bankAccount.BankAccountBalance = account.BankAccountBalance;
            _context.SaveChanges();
            return Task.FromResult(new BankAccountDTO
            {
                BankAccountId = bankAccount.BankAccountId,
                BankAccountName = bankAccount.BankAccountName,
                BankAccountBalance = bankAccount.BankAccountBalance
            });
        }



        public Task<bool> DeleteBankAccAsync(int id)
        {
            var account = _context.BankAccounts.Find(id);
            if (account == null)
            {
                return Task.FromResult(false);
            }
            _context.BankAccounts.Remove(account);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
