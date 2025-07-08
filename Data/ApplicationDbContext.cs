//ApplicationDbContext.cs
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BorrowRecord> BorrowRecord { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BookRequest> BookRequests { get; set; }

    }
}
