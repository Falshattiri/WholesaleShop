using WholesaleShop.Models;

namespace WholesaleShop.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    
    Task<Product> CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id); 
    
    Task<bool> IsStockAvailableAsync(int productId, int qty);

   
}