using System.Linq.Expressions;
using BookmateApp.Entities;

namespace BookmateApp.Infrastructure.Repositories;

public interface IRepository<T> where T : class, IEntity, new()  
{
    // generic queries
    Task<T?> GetAsync(Guid id);
    Task<IList<T>> GetAllAsync();
    Task<bool> IsExistAsync(Guid id);

    // generic commands
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}