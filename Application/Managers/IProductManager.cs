using Entities;
using System.Collections.Generic;

namespace Application.Managers
{
    public interface IProductManager
    {
        string CreateProduct(Product product);
        List<Product> GetProducts();
        Product GetProductById(int productid);

        string UpdateProduct(Product product);
        string DeleteProduct(int id);
    }
}
