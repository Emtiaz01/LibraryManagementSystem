using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var book = (from b in _context.Book
                        join c in _context.Category on b.CategoryId equals c.CategoryId
                        select new BookViewModel
                        {
                            BookId = b.BookId,
                            Title = b.Title,
                            Author = b.Author,
                            ISBN = b.ISBN,
                            PublisherName = b.PublisherName,
                            PublishedDate = b.PublishedDate,
                            TotalCopies = b.TotalCopies,
                            AvailableCopies = b.AvailableCopies,
                            CoverImageURL = b.CoverImageURL,
                            BorrowRecords = _context.BorrowRecord.Where(br => br.BookId == b.BookId).ToList(),
                            CategoryId = b.CategoryId,
                            CategoryName = c.CategoryName
                        }).ToList();

            return View(book);
        }


        // GET: Create Book page
        public IActionResult CreateBook()
        {
            var categories = _context.Category
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryId.ToString()  
                })
                .ToList();

            ViewBag.Category = categories;

            return View();
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

        // GET: Edit Book
        public IActionResult EditBook(int id)
        {
            var book = _context.Book.FirstOrDefault(b => b.BookId == id);

            if (book == null)
                return NotFound();
            var categories = _context.Category
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryId.ToString()
                })
                .ToList();

            ViewBag.Category = categories;

            return View(book);
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
            return Ok();
        }
    }
}
