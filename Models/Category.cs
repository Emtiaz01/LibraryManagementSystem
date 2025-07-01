using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? BookName { get; set; } = string.Empty;
        public string? CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
