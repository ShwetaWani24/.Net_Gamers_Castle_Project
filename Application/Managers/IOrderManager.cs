using Entities;


namespace Application.Managers
{
    public interface IOrderManager
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int OrderId);
        List<Order> GetOrdersByCity(String city);
        //List<Order> GetOrdersByUser(String userName);
        List<Order> GetOrderByProduct(int ProductId);
        String UpdateOrderDate(int Id, DateTime Date);
        String UpdateOrderStatus(int Id, String status);
        String AddOrder(Order order);
    }
}

