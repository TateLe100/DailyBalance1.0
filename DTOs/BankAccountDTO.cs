using System.ComponentModel.DataAnnotations;

namespace DailyBalance1._0.DTOs
{
    public class BankAccountDTO
    {
        public int BankAccountId { get; set; }
        [Required]
        public string BankAccountName { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive number.")]
        public decimal BankAccountBalance { get; set; }
    }
}
