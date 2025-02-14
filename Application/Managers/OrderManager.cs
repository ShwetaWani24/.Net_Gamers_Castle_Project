using Application.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Managers
{
    public class OrderManager : IOrderManager
    {
        public List<Order> GetAllOrders()
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Orders.Include(o => o.user).Include(o => o.product).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Order> GetOrderByProduct(int ProductId)
        {
            List<Order> data = new List<Order>();
            List<Order> orders = new List<Order>();

            using (var context = new MyDbContext())
            {
                data = context.Orders.Include(o => o.product).Include(o => o.user).ToList();
            }
            if (data != null)
            {
                foreach (var d in data)
                {
                    if (d.product.ProductId == ProductId)
                    {
                        orders.Add(d);
                    }
                }
            }
            return orders;
        }

        public List<Order> GetOrdersByCity(string city)
        {
            List<Order> OrderSet = new List<Order>();
            using (var context = new MyDbContext())
            {
                List<Order> orders = context.Orders.Include(o => o.user).Include(o => o.product).ToList();
                foreach (var o in orders)
                {
                    if (o.user.Address.Equals(city))
                    {
                        OrderSet.Add(o);
                    }
                }
            }
            return OrderSet;
        }

        //public List<Order> GetOrdersByUser(string userName)
        //{
        //    throw new NotImplementedException();
        //}

        public string UpdateOrderDate(int Id, DateTime Date)
        {
            using (var context = new MyDbContext())
            {
                Order order = context.Orders.Find(Id);
                order.OrderDate = Date;
                context.SaveChanges();
            }
            return "Date Updated Successfully...";
        }

        public string UpdateOrderStatus(int Id, string status)
        {

            using (var context = new MyDbContext())
            {
                Order o = context.Orders.Find(Id);
                if (o != null)
                {
                    o.OrderStatus = status;
                    context.SaveChanges();
                    return "Order Status Updated Successfully...";
                }
            }
            return "No Such Order Found in Data base";
        }
        public String AddOrder(Order o)
        {
            using (var context = new MyDbContext())
            {
                o.OrderStatus = "Pending";
                context.Orders.Add(o);
                context.SaveChanges();
            }
            return "Order Placed Successfully...";
        }
    
    public Order GetOrderById(int orderId)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Orders.Find(orderId);

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving order by ID.", e);
            }
        }
    }
    }

