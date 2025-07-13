//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace LibraryManagementSystem.Controllers
//{
//    public class AdminController : Controller
//    {

//        public IActionResult Index()
//        {
//            var isAdmin = HttpContext.Session.GetString("IsAdmin");
//            if (isAdmin != "true")
//            {
//                return RedirectToPage("Index");
//            }

//            return View();
//        }
//    }
//}

