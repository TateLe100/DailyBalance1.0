using System.ComponentModel.DataAnnotations.Schema;

namespace DailyBalance1._0.Models
{
    public class Budget
    {
        public int BudgetID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Month { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal RemainingBalance { get; set; }
        public int UserID { get; set; }
        //public virtual User? UserId { get; set; }


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
