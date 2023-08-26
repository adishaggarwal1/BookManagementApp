using Microsoft.AspNetCore.Mvc;
using TeamB.BookManagement;

namespace BooksWeb.Controllers
{
    public class LoginController : Controller
    {
        IUserService userService;
        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<ViewResult> Index()
        {            
            return View();
        }

        public async Task<ActionResult> Validate(string email, string password)
        {
            var user = await userService.GetUserById(email);
            if(user == null || password != user.Password)
            {
                return RedirectToAction("Index", "Register"); // Redirecting to register page
            }
            return RedirectToAction("Index", "Author");
        }

    }
}
