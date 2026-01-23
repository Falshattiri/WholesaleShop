using WholesaleShop.Models;

namespace WholesaleShop.Services.Interfaces;

public interface IPaymentService
{
   Task<Payment> CreateCustomerPaymentAsync(int customerId, decimal amount, DateTime paymentDate, string? notes = null);  
   Task<Payment> CreateSupplierPaymentAsync(int supplierId, decimal amount, DateTime paymentDate, string? notes = null);
   
   Task<IEnumerable<Payment>> GetCustomerPaymentsAsync(int customerId);
   Task<IEnumerable<Payment>> GetSupplierPaymentsAsync(int supplierId);

}