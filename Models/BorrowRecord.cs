//BorrowRecord.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        [Key]
        public int BorrowId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }  
        public int FineAmount { get; set; }
    }
}
