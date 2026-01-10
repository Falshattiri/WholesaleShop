using Microsoft.EntityFrameworkCore;
using WholesaleShop.Data;
using WholesaleShop.Repositories.Interfaces;

namespace WholesaleShop.Repositories.Implementations;

public class MainRepository<T> : IRepository<T> where T : class


{
    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<T> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }
}