using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Managers;
using System.Collections.Generic;
using Entities;
using System.Diagnostics;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ProductManager productManager = new ProductManager();

            List<Product> products = productManager.GetProducts();


            return View(products);
        }

        public IActionResult IndexAfterLogin()
        {
            ProductManager productManager = new ProductManager();

            List<Product> products = productManager.GetProducts();


            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
