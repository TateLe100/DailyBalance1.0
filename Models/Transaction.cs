using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyBalance1._0.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public string TransactionName { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public decimal TransactionAmount { get; set; }
        public string? TransactionDescription { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }
        public virtual BankAccount? BankAcccount { get; set; }

    }
}
