using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Book list
        public IActionResult Index()
        {
            var books = _context.Book.ToList();
            return View(books);
        }

        // GET: Create Book page
        public IActionResult CreateBook()
        {
            return View();
        }

        // GET: Edit Book
        public IActionResult EditBook(int id)
        {
            var book = _context.Book.FirstOrDefault(b => b.BookId == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: Create Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: Edit Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(int id, Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedBook);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("EditBook", updatedBook);
        }

        // POST: Delete via SweetAlert + AJAX
        [HttpPost]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Book.FirstOrDefault(b => b.BookId == id);

            if (book == null)
                return NotFound();

            _context.Book.Remove(book);
            _context.SaveChanges();
            return Ok(); // For AJAX success
        }
    }
}
