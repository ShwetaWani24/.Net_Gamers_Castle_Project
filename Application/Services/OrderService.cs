using Application.Managers;
using Entities;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private IOrderManager orderManager;

        public OrderService(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }
        public List<Order> SearchOrderByCity(string city)
        {
            return orderManager.GetOrdersByCity(city);
        }

        public List<Order> SearchOrderByProduct(Product product)
        {
            return orderManager.GetOrderByProduct(product.ProductId);
        }

        public List<Order> ShowAllOrders()
        {
            return orderManager.GetAllOrders();
        }

        public string UpdateOrderDate(int Id,string date)
        {
            string format = "dd/MM/yyyy";
            DateTime Date = DateTime.ParseExact(date, format, null);
            return orderManager.UpdateOrderDate(Id, Date);
        }

        public string UpdateOrderStatus(int Id, string Status)
        {
            return orderManager.UpdateOrderStatus(Id, Status);
        }
        public void AddOrder(Order order)
        {
            orderManager.AddOrder(order);
        }
    }
}
