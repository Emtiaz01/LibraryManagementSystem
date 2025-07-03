using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Book list
        public IActionResult Index()
        {
            var category = _context.Category.ToList();
            return View(category);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category category)
        {


            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public IActionResult EditCategory(int id)
        {
            var category = _context.Category.FirstOrDefault(b => b.CategoryId == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Edit Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, Category updateCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updateCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("EdiCategory", updateCategory);
        }

        // POST: Delete via SweetAlert + AJAX
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Category.FirstOrDefault(b => b.CategoryId == id);

            if (category == null)
                return NotFound();

            _context.Category.Remove(category);
            _context.SaveChanges();
            return Ok(); // For AJAX success
        }
    }
}
