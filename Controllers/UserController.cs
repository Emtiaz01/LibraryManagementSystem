//UserController.cs
using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using LibraryManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly RoleManager<IdentityRole> _role;
        public UserController(UserManager<IdentityUser>user, RoleManager<IdentityRole> role)
        {
            _role = role;
            _user = user;
        }
        public IActionResult Index()
        {
           return View();
        }
        public async Task<IActionResult> UserDetail()
        {
            var GetUser = _user.Users.ToList(); 
            var userRole = new List<UserRoleViewModel>();
            foreach (var user in GetUser)
            {
                var roles = await _user.GetRolesAsync(user);
                userRole.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Roles = roles.ToList()
                });
            }
            return View(userRole);
        }
    }
}
