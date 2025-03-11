using DailyBalance1._0.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DailyBalance1._0.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensure Identity setup

            // Define relationships
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BankAccount>()
                .HasMany(b => b.Transactions)
                .WithOne(t => t.BankAccount)
                .HasForeignKey(t => t.BankAccountId);
        }
    }
}
