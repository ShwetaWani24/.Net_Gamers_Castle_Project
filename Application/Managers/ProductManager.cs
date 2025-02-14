using Application.Contexts;
using Entities;

namespace Application.Managers
{
    public class ProductManager : IProductManager
    {
        public ProductManager()
        {
        }

        public string CreateProduct(Product product)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    context.Products.Add(product);
                    context.SaveChanges();

                    return "Product Added Successfully...";
                }
                catch
                {
                    return "Something Went Wrong";
                }
            }
        }
        public List<Product> GetProducts()
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    var emp = context.Products.ToList();
                    return emp;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public String UpdateProduct(Product p)
        {
            //bool flag=false;
            try
            {
                using (var context = new MyDbContext())
                {
                    Product product = context.Products.Find(p.ProductId);
                    if (product != null)
                    {
                        //flag = true;
                        product.ProductName = p.ProductName;
                        product.Price = p.Price;
                        product.Description = p.Description;
                        product.Stock = p.Stock;
                        context.SaveChanges();
                        return "Updated Successfully...";
                    }

                }
                return "Product Not Found...";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public String DeleteProduct(int Id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    Product product = context.Products.Find(Id);
                    if (product != null)
                    {
                        context.Remove(product);
                        context.SaveChanges();
                        return "Product Deleted Successfully...";
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return "Product Not Found";
        }

        public Product GetProductByName(string Name)
        {
            using (var context = new MyDbContext())
            {
                Product product = context.Products.FirstOrDefault(p => p.ProductName.Equals(Name));
                if (product != null)
                {
                    return product;
                }
            }

            return null;
        }
        public Product GetProductById(int productId)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                    if (product == null)
                    {
                        throw new Exception($"Product with ID {productId} not found.");
                    }
                    return product;
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while retrieving the product.", e);
            }
        }
    }
}


