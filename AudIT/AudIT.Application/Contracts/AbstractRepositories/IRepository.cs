using System.Linq.Expressions;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IRepository<T> where T : class
{
    Task<Result<T>> UpdateAsync(T entity);
    Task<Result<IReadOnlyList<T>>> GetAllAsync();
    Task<Result<T>> FindByIdAsync(Guid id);
    Task<Result<T>> AddAsync(T entity);
    Task<Result<T>> RemoveAsync(T entity);
    Task<Result<T>> DeleteAsync(Guid id);
    Task<Result<IReadOnlyList<T>>> GetPagedResponseAsync(int page, int size);
    Task<Result<IReadOnlyList<T>>> GetByFilterAsync(Expression<Func<T, bool>> filter);

}