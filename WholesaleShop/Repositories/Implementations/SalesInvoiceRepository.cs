using WholesaleShop.Data;
using WholesaleShop.Models;
using WholesaleShop.Repositories.Interfaces;

namespace WholesaleShop.Repositories.Implementations;

public class SalesInvoiceRepository: MainRepository<SalesInvoice>, ISalesInvoiceRepository
{
    
    private readonly AppDbContext _context;
    public SalesInvoiceRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}