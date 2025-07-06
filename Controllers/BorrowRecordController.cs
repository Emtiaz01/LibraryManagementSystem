//BorrowRecordController.cs
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowRecordController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET: Borrow Record
        public IActionResult Index()
        {
            var record = _context.BorrowRecord.ToList();
            return View(record);
        }

        //GET: Add Record
        public IActionResult AddRecord()
        {
            return View();
        }
        // POST: Add Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecord(BorrowRecord record)
        {
            _context.BorrowRecord.Add(record);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Edit Record
        public IActionResult EditRecord(int id)
        {
            var record = _context.BorrowRecord.FirstOrDefault(b => b.BorrowId == id);

            if (record == null)
                return NotFound();

            return View(record);
        }
        // POST: Edit Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRecord(int id, BorrowRecord updateRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updateRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("EditBook", updateRecord);
        }

        // POST: Delete via SweetAlert + AJAX
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteRecord(int id)
        {
            var record = _context.BorrowRecord.FirstOrDefault(b => b.BorrowId == id);

            if (record == null)
                return NotFound();

            _context.BorrowRecord.Remove(record);
            _context.SaveChanges();
            return Ok();
        }

    }
}
