using Microsoft.AspNetCore.Mvc;
using Entities;
using Application.Managers;
using Application.Services;

namespace Application.Controllers
{
    public class AdminController : Controller
    {
        private IProductService productService;
        private IProductManager productManager;
        private IOrderManager orderManager;
        private IOrderService orderService;
        public AdminController(IProductService productService, IProductManager productManager,IOrderManager orderManager, IOrderService orderService)
        {
            this.productService = productService;
            this.productManager = productManager;
            this.orderManager = orderManager;
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productService.AddProduct(product);
            return RedirectToAction("ShowAllProducts");
        }
        [HttpGet]
        public IActionResult UpdateProduct()
        {
            this.ViewBag.Products = productService.ShowProducts();
            return View();
        }
        [HttpPost]
        public IActionResult DeleteProduct(int ProductId)
        {
            productService.DeleteProduct(ProductId);
            return RedirectToAction("ShowAllProducts");
        }
        public IActionResult ShowAllProducts()
        {
            this.ViewBag.Products = productService.ShowProducts();
            return View();
        }
        //---------------------------------------------------------------------------Order//
        public IActionResult OrdersMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateOrderStatus(int orderId,String orderStatus)
        {
            orderManager.UpdateOrderStatus(orderId, orderStatus);
            return RedirectToAction("ShowOrders");
        }
        public IActionResult UpdateOrderDate(int orderId, String orderDateTime)
        {
            orderService.UpdateOrderDate(orderId, orderDateTime);
            return RedirectToAction("ShowOrders");
        }
        [HttpPost]
        public IActionResult SearchOrderByProduct(string productName)
        {
            List<Product> list = productManager.GetProducts();
            Product product = new Product();
            foreach(var p in list)
            {
                if(p.ProductName.Equals(productName))
                {
                   product=p;
                }
            }
            List<Order> data=orderManager.GetOrderByProduct(product.ProductId);
            this.ViewBag.Orders = data;
            return View();
        }
        [HttpPost]
        public IActionResult SearchOrderByCity(String cityName)
        {
            this.ViewBag.Orders=orderManager.GetOrdersByCity(cityName);
            return View();
        }
        public IActionResult ShowOrders()
        {
            List<Order>list = new OrderManager().GetAllOrders();
            this.ViewBag.Orders = list;
            return View();
        }
    }
}
