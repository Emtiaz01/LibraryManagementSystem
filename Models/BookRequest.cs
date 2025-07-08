using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class BookRequest
    {
        [Key]
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateOnly RequestDate { get; set; }
        public bool? IsApproved { get; set; }
        public DateOnly ApprovalDate { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        
    }
}
