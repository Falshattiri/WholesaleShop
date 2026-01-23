using WholesaleShop.Models;

namespace WholesaleShop.Services.Interfaces;

public interface ISupplierService
{
    
    // 
    Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
    Task<Supplier> GetSuppliersByIdAsync(int id);
    Task<Supplier> CreateSupplierAsync(Supplier supplier);
    Task UpdateSupplierAsync(Supplier supplier);
    Task DeleteSupplierAsync(int id);
    Task<bool> IsSupplierExistAsync(int id);
    



}