using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Entities;
using Application.Managers;

namespace Application.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderManager _orderManager;

        public ProductController(IProductService productService, IOrderManager orderManager)
        {
            _productService = productService;
            _orderManager = orderManager;
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = _productService.ShowProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult BuyNow(int productId)
        {
            var product = _productService.ShowProducts().FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                TempData["ErrorMessage"] = "Product not found.";
                return RedirectToAction("List");
            }

            if (product.Stock <= 0)
            {
                TempData["ErrorMessage"] = "This product is out of stock.";
                return RedirectToAction("List");
            }

            // Pass the quantity to the view (default to 1 if not specified)
            ViewBag.Quantity = 1; // You can modify this to allow the user to specify the quantity
            ViewBag.TotalPrice = product.Price * ViewBag.Quantity;

            return View(product);
        }
        [HttpPost]
        public IActionResult BuyNowConfirm(int productId, int quantity)
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (userId == null)
            {
                TempData["ErrorMessage"] = "Please log in to complete your purchase.";
                return RedirectToAction("Login", "User", new { returnUrl = Url.Action("BuyNow", new { productId }) });
            }

            var product = _productService.ShowProducts().FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                TempData["ErrorMessage"] = "Product not found.";
                return RedirectToAction("List");
            }

            if (product.Stock < quantity)
            {
                TempData["ErrorMessage"] = "Insufficient stock for this product.";
                return RedirectToAction("List");
            }

            var totalPrice = product.Price * quantity;

            var order = new Order
            {
                UserId = int.Parse(userId),
                ProductId = productId,
                OrderDate = DateTime.Now,
                Total = totalPrice
                // Add quantity to the order
            };

            _orderManager.AddOrder(order);

            // Update product stock
            product.Stock -= quantity;
            _productService.UpdateProduct(product);

            return RedirectToAction("OrderConfirmation", "Order", new { orderId = order.OrderId });
        }
    }
}
