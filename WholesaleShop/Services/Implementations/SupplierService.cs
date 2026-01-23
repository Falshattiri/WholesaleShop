using WholesaleShop.Models;
using WholesaleShop.Services.Interfaces;
using WholesaleShop.UnitOfWork.Interfaces;

namespace WholesaleShop.Services.Implementations;

public class SupplierService : ISupplierService
{
    private readonly IUnitOfWork _unitOfWork;
    public SupplierService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
    {
        var supplier = await _unitOfWork.Suppliers.GetAllAsync();
        return supplier.Where(s => s.IsDeleted);
    }

    public Task<Supplier?> GetSuppliersByIdAsync(int id)
    {
        return _unitOfWork.Suppliers.GetByIdAsync(id);
    }

    public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
    {
        await _unitOfWork.Suppliers.CreateAsync(supplier);
        await _unitOfWork.SaveAsync();
        
        return supplier;
    }

    public async Task UpdateSupplierAsync(Supplier supplier)
    {
        var updateSupplier = await _unitOfWork.Suppliers.GetByIdAsync(supplier.Id);
        if (updateSupplier == null)
            throw new Exception("Supplier not found");
        
        updateSupplier.Name = supplier.Name; // Only name
        
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteSupplierAsync(int id)
    {
        var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
        if (supplier == null)
            throw new Exception("Product not found.");

        supplier.IsDeleted = false;   //  Soft Delete
        await _unitOfWork.SaveAsync();
    }

    public Task<bool> IsSupplierExistAsync(int id)
    {
        throw new NotImplementedException();
    }
}