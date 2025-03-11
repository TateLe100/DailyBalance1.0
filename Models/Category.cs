using System.ComponentModel.DataAnnotations;

namespace DailyBalance1._0.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
