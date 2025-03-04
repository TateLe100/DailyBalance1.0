namespace DailyBalance1._0.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; }
        public decimal BankAccountBalance { get; set; }
        public int UserID { get; set; }
        //public virtual User? UserId { get; set; }
    }
}
