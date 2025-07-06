//BookViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class BookViewModel
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string PublisherName { get; set; }
        public DateOnly PublishedDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CoverImageURL { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public List<BorrowRecord> BorrowRecords { get; set; }
    }
}
