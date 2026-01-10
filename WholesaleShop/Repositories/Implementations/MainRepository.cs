using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WholesaleShop.Data;
using WholesaleShop.Repositories.Interfaces;

namespace WholesaleShop.Repositories.Implementations;

public class MainRepository<T> : IRepository<T> where T : class
{
    
    private readonly AppDbContext _context;

    public MainRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    /*
     #Notes:
       - Set<T>() gives access to DbSet<T> for the entity type.
       - T -> Entity type (Class) mapped to a database table
       - Entity -> Object (instance) created from that class
       - IQueryable<T> Query() -> Used for building queries (search, filter, reports)
     */ 
    
    public async Task<IEnumerable<T>> GetAllAsync() 
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }
    public async Task<T?> GetByIdAsync(int id)
    {
       return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    
    // إستثناء
    public IQueryable<T> Query()
    {
        return _context.Set<T>().AsNoTracking();
    }
    
}