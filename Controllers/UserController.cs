//UserController.cs
using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //public UserController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            //var user = _context.Users.ToList();
            return View();
        }
    }
}
