using WholesaleShop.Models;
using WholesaleShop.Repositories.Implementations;
using WholesaleShop.Repositories.Interfaces;

namespace WholesaleShop.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    
    // Generic repositories (CRUD operations)
    IRepository<Customer> Customers { get; }
    IRepository<Supplier> Suppliers { get; }
    IRepository<Product> Products { get; }
    IRepository<Payment> Payments { get; }
    
    // Specific repositories
    PurchaseInvoiceRepository PurchaseInvoices { get; }
    SalesInvoiceRepository SalesInvoices { get; }
    
    // Commit all changes as a single unit of work
    Task SaveAsync();
}