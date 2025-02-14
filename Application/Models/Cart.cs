using Application.Models;
using Entities;

namespace Entities
{

    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddToCart(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.ProductId);
            if (existingItem == null)
            {
                Items.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    Quantity = quantity,
                    Product = product
                });
            }
            else
            {
                existingItem.Quantity += quantity;
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(item => item.Product.Price * item.Quantity);
        }
    }


}
