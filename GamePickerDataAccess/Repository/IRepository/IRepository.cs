using System.Linq.Expressions;

namespace GamePickerDataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(string? includeItems = null);
    T Get(Expression<Func<T, bool>> filter, string? includeItems = null);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);
}