using WholesaleShop.Data;
using WholesaleShop.Models;
using WholesaleShop.Services.Interfaces;
using WholesaleShop.UnitOfWork.Interfaces;

namespace WholesaleShop.Services.Implementations;

public class CustomerService : ICustomerService {
    
    // Use UnitOfWork to coordinate repositories and save changes as a single transaction
    private readonly IUnitOfWork _unitOfWork;
    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var customer = await _unitOfWork.Customers.GetAllAsync();
        return customer.Where(c => c.IsDeleted);
    }

    public Task<Customer?> GetCustomerAsync(int id)
    {
        return _unitOfWork.Customers.GetByIdAsync(id);
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        await _unitOfWork.Customers.CreateAsync(customer);
        await _unitOfWork.SaveAsync();

        return customer;
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        var updatedCustomer = await _unitOfWork.Customers.GetByIdAsync(customer.Id);
        if (updatedCustomer == null)
             throw new Exception("Customer not found.");
       
        updatedCustomer.PasswordHash = customer.PasswordHash;
        updatedCustomer.Email = customer.Email;
        updatedCustomer.Name = customer.Name;

        await _unitOfWork.SaveAsync();
        
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var deletedCustomer = await _unitOfWork.Customers.GetByIdAsync(id);
        if ( deletedCustomer == null)
            throw new Exception("Customer not found.");
        
        deletedCustomer.IsDeleted = false;
        
        await _unitOfWork.SaveAsync();
        
    }

    public Task<bool> IsCustomerExistAsync(int id)
    {
        throw new NotImplementedException();
    }
}