using BooksWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TeamB.BookManagement;

namespace BooksWeb.Controllers
{
    public class RegisterController : Controller
    {
        IUserService userService;
        public RegisterController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<ViewResult> Index() 
        {
            return View();
        }

        public async Task<ActionResult> Add(User user)
        {
            if (ModelState.IsValid)
            {
                await userService.AddUser(user);
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index"); //should be chnaged
        }
    }
}
