using WholesaleShop.Data;
using WholesaleShop.Models;
using WholesaleShop.Repositories.Interfaces;

namespace WholesaleShop.Repositories.Implementations;

public class PurchaseInvoiceRepository: MainRepository<PurchaseInvoice>, IPurchaseInvoiceRepository
{
    private readonly AppDbContext _context;
    public PurchaseInvoiceRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}