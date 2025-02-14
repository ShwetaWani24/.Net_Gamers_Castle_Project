using Microsoft.AspNetCore.Mvc;
using Entities;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Application.Managers;

namespace Application.Controllers
{
    public class UserController : Controller
    {
       
        private readonly UserServices _userServices;
        private readonly IOrderManager _orderManager;

        public UserController(UserServices userServices, IOrderManager orderManager)
        {
           
            _userServices = userServices;
            _orderManager = orderManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                // If validation fails, return the view with the model to display errors
                return View(user);
            }

            // If validation passes, add the user
            _userServices.AddUser(user);

            // Set a success message
            TempData["SuccessMessage"] = "Registration successful! Please log in.";

            // Redirect to the Login page
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _userServices.AuthenticateUser(email, password);

                if (existingUser != null)
                {
                    HttpContext.Session.SetString("UserId", existingUser.UserId.ToString());
                    HttpContext.Session.SetString("UserName", existingUser.Name);
                    HttpContext.Session.SetString("UserEmail", existingUser.Email);
                    HttpContext.Session.SetString("UserRole", existingUser.Role);

                    ViewData["UserName"] = HttpContext.Session.GetString("UserName");

                    if (existingUser.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("IndexAfterLogin", "Home");
                    }
                }

                ModelState.AddModelError("", "Invalid email or password.");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "You have been logged out.";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult MyCart()
        {
            return RedirectToAction("MyCart", "Order"); // Redirecting to Order Controller's MyCart action
        }

       

        
    }
}
