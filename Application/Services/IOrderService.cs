using Entities;

namespace Application.Services
{
    public interface IOrderService
    {
        List<Order> ShowAllOrders();
        List<Order> SearchOrderByCity(string city);
        List<Order> SearchOrderByProduct(Product product);
        String UpdateOrderDate(int Id,string date);
        String UpdateOrderStatus(int Id, String Status);
    }
}
