using Microsoft.AspNetCore.Mvc;
using BlazedCosmos.Models;
using BlazedCosmos.Services.Interfaces;

namespace BlazedCosmos.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var authenticatedUser = _userService.Authenticate(user.Username, user.Password);
            if (authenticatedUser != null)
            {
                // Simulate login (in real apps, use Identity or JWT)
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Register(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}
