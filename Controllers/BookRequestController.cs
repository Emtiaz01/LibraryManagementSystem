using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
