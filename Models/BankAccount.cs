using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyBalance1._0.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }
        [Required]
        public string BankAccountName { get; set; }
        [Required]
        public decimal BankAccountBalance { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
