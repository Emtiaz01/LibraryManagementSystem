namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public string PublisherNAme { get; set; }
        public DateOnly PublishedDate { get; set; }
        public int CategoryId { get; set; }
        public string CoverImageURL { get; set; }
        public int TotalCopies { get; set; }    
        public int AvailableCopies { get; set; }
        public DateTime BorrowRecords {  get; set; }
    }
}
