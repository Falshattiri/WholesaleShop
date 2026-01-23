using WholesaleShop.Models;
using WholesaleShop.Services.Interfaces;

namespace WholesaleShop.Services.Implementations;

public class PaymentService : IPaymentService
{
    public Task<Payment> CreateCustomerPaymentAsync(int customerId, decimal amount, DateTime paymentDate, string? notes = null)
    {
        throw new NotImplementedException();
    }

    public Task<Payment> CreateSupplierPaymentAsync(int supplierId, decimal amount, DateTime paymentDate, string? notes = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Payment>> GetCustomerPaymentsAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Payment>> GetSupplierPaymentsAsync(int supplierId)
    {
        throw new NotImplementedException();
    }
}