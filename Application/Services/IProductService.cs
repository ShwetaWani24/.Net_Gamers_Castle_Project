using Entities;

namespace Application.Services
{
    public interface IProductService
    {
        String AddProduct(Product p);
        List<Product> ShowProducts();
        String UpdateProduct(Product p);
        String DeleteProduct(int Id);

        Product GetProductById(int productId);
    }
}
