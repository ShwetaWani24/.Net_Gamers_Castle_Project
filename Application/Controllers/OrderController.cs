using Microsoft.AspNetCore.Mvc;
using Application.Managers;
using Application.Services;
using Entities;
namespace Application.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            
            this._orderManager = orderManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult OrderConfirmation(int orderId)
        {

            var order = _orderManager.GetOrderById(orderId);

            if (order == null)
            {

                return RedirectToAction("List");
            }
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            return View("OrderConfirmation", order);
        }

        

        [HttpGet]
        public IActionResult MyOrders()
        {
            
            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Please log in to view your orders.";
                return RedirectToAction("Login", "User");
            }
            int id = int.Parse(userId);
            List<Order> orders = _orderManager.GetAllOrders();
            List<Order> data = _orderManager.GetAllOrders();
            foreach (Order order in orders)
            {
                if (order.UserId == id)
                {
                   data.Add(order);
                }
            }
            // Get the user's orders
            this.ViewBag.orders = data;

            // Pass the orders to the view
            return View();
        }
    
}
}
