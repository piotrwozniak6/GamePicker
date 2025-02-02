using System.Linq.Expressions;
using GamePickerDataAccess.Data;
using GamePickerDataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GamePickerDataAccess.Repository;

public class Repository<T>: IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDbContext db)
    {
        _db = db;
        this.dbSet = _db.Set<T>();
        _db.GameModels.Include(u => u.Category);
    }
    
    public IEnumerable<T> GetAll(string? includeItems = null)
    {
        IQueryable<T> query = dbSet;
        if (!string.IsNullOrEmpty(includeItems))
        {
            foreach (var includeItem in includeItems
                         .Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeItem);
            }
        }
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter, string? includeItems = null)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        
        if (!string.IsNullOrEmpty(includeItems))
        {
            foreach (var includeItem in includeItems
                         .Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeItem);
            }
        }
        return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}