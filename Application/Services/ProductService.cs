using Application.Managers;
using Entities;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private IProductManager manager;

        public ProductService(IProductManager manager)
        {
            this.manager = manager;
        }

        public string AddProduct(Product p)
        {
            return manager.CreateProduct(p);
        }

        public string DeleteProduct(int Id)
        {
            return manager.DeleteProduct(Id);
        }

        public List<Product> ShowProducts()
        {
            return manager.GetProducts();
        }

        public string UpdateProduct(Product p)
        {
            return manager.UpdateProduct(p);
        }
        public Product GetProductById(int productId)
        {
            return manager.GetProductById(productId);
        }
    }
}
