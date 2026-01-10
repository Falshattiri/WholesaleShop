namespace WholesaleShop.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    // Use CRUD (Create - Read - Update - Delete)
    
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
    
    
}