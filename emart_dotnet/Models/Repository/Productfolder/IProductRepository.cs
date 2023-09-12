using Emart_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Productfolder
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<Product?> DeleteProduct(int productId);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int productId);
        Task<Product?> UpdateProduct(int productId, Product updatedProduct);
        Task<IEnumerable<Product>> GetProductsByPriceRange(double minPrice, double maxPrice);
        Task<IEnumerable<Product>> GetProductsWithValidDiscount();
        Task<IEnumerable<Product>> FindByCatID(int id);
    }
}
