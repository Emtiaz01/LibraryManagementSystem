//using LibraryManagementSystem.Data;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//public class AdminLoginModel : PageModel
//{
//    private readonly ApplicationDbContext _context;

//    public AdminLoginModel(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    [BindProperty]
//    [Required]
//    [EmailAddress]
//    public string Email { get; set; }

//    [BindProperty]
//    [Required]
//    [DataType(DataType.Password)]
//    public string Password { get; set; }

//    public string ErrorMessage { get; set; }

//    public async Task<IActionResult> OnPostAsync()
//    {
//        if (!ModelState.IsValid)
//        {
//            return Page();
//        }

//        var admin = _context.Admins.FirstOrDefault(a => a.Email == Email && a.Password == Password);

//        if (admin != null)
//        {
//            //HttpContext.Session.SetString("IsAdmin", "true");
//            //HttpContext.Session.SetString("AdminEmail", admin.Email);
//            return Redirect("/Admin/Index");
//        }
//        else
//        {
//            ErrorMessage = "Invalid login credentials.";
//            return Page();
//        }
//    }
//}
