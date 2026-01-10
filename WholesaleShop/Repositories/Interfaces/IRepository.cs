namespace WholesaleShop.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    
    //Select All (Read)
    Task<IEnumerable<T>> GetAllAsync();
    
    // Select By ID (Read)
    Task<T?> GetByIdAsync(int id);
    
    //Create 
    Task<T> CreateAsync(T entity);
    
    //Update
    void Update(T entity);
    
    //Delete
    void Delete(T entity);
    
    // Used for building queries (search, filter, reports) -
    IQueryable<T> Query();
    
}