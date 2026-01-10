using Microsoft.EntityFrameworkCore;
using WholesaleShop.Data;
using WholesaleShop.Models;
using WholesaleShop.Repositories.Implementations;
using WholesaleShop.Repositories.Interfaces;
using WholesaleShop.UnitOfWork.Interfaces;

namespace WholesaleShop.UnitOfWork.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        
        // CRUD - Main repository
        Customers = new MainRepository<Customer>(_context);
        Suppliers = new MainRepository<Supplier>(_context);
        Products  = new MainRepository<Product>(_context);
        Payments  = new MainRepository<Payment>(_context);
        
        // Specific repositories (Invoices)
        SalesInvoices = new SalesInvoiceRepository(_context);
        PurchaseInvoices = new PurchaseInvoiceRepository(_context);
        
    }
    
    public IRepository<Customer> Customers { get; }
    public IRepository<Supplier> Suppliers { get; }
    public IRepository<Product> Products { get; }
    public IRepository<Payment> Payments { get; }
    
    public PurchaseInvoiceRepository PurchaseInvoices { get; }
    public SalesInvoiceRepository SalesInvoices { get; }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }


}