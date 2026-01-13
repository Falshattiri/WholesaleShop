using WholesaleShop.Data;
using WholesaleShop.Models;
using WholesaleShop.Services.Interfaces;
using WholesaleShop.UnitOfWork.Interfaces;

namespace WholesaleShop.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    
    // Business rules and use cases for products (Product business logic)
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return products.Where(p => p.IsDeleted);
        // return _unitOfWork.Products.GetAllAsync().
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        return _unitOfWork.Products.GetByIdAsync(id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
       await _unitOfWork.Products.CreateAsync(product);
       await _unitOfWork.SaveAsync();
      
       // In Repo return entity
       return product; 
       
    }

    public async Task UpdateProductAsync(Product product)
    {
        var updatedProduct = await _unitOfWork.Products.GetByIdAsync(product.Id);
        if (updatedProduct == null)
            throw new Exception("Product not found");
        
        updatedProduct.Name = product.Name;
        updatedProduct.UnitPrice = product.UnitPrice;
        updatedProduct.StockQty = product.StockQty;
        
       // _unitOfWork.Products.Update(product);
       await _unitOfWork.SaveAsync();
       
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
            throw new Exception("Product not found.");

        product.IsDeleted = false;   // 👈 Soft Delete
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> IsStockAvailableAsync(int productId, int qty)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(productId);
        return product != null && product.StockQty >= qty;
        
    }
}