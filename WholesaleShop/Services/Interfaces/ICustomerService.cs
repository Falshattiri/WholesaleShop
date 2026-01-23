using WholesaleShop.Models;

namespace WholesaleShop.Services.Interfaces;

public interface ICustomerService
{
    // Get All Customers by IEnumerable that be faster
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    
    // Get Customer By ID
    Task<Customer?> GetCustomerAsync(int id);
    
    // Create New Customer
    Task<Customer> CreateCustomerAsync(Customer customer);
    
    // Update Customer
    Task UpdateCustomerAsync(Customer customer);
    
    // Delete Customer
    Task DeleteCustomerAsync(int id);
    
    // Soft Delete
    Task<bool> IsCustomerExistAsync(int id);
    
}