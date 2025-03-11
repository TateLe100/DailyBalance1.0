using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyBalance1._0.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }
        [Required]
        public DateTime Month { get; set; }
        [Required]
        public decimal TotalBudget { get; set; }
        [Required]
        public decimal RemainingBalance { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }


        // ---------------- Put this in a view model instead ----------------
        //public int DaysLeftInMonth => GetDaysLeftInMonth();

        //public decimal DailyLimit => (DaysLeftInMonth > 0) ? RemainingBalance / DaysLeftInMonth : 0;

        //private int GetDaysLeftInMonth()
        //{
        //    var lastDayOfMonth = new DateTime(Month.Year, Month.Month, DateTime.DaysInMonth(Month.Year, Month.Month));
        //    int daysLeft = (lastDayOfMonth - DateTime.Today).Days;
        //    return daysLeft > 0 ? daysLeft : 0;
        //}
        // -----------------------------------------------------------------
    }
}
