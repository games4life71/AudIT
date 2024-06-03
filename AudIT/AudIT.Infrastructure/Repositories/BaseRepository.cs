using System.Linq.Expressions;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    public readonly AudITContext _dbcContext;

    public BaseRepository(AudITContext context)
    {
        _dbcContext = context;
    }


    public async Task<Result<IReadOnlyList<T>>> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        try
        {
            // var result = await _dbcContext.Set<T>().Where(filter).ToListAsync();
            var result = _dbcContext.Set<T>().ToListAsync();
            var filteredResult = result.Result.Where(filter.Compile()).ToList();

            if (result == null)
            {
                return Result<IReadOnlyList<T>>.Failure("No entities found.");
            }

            return Result<IReadOnlyList<T>>.Success(filteredResult);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result<IReadOnlyList<T>>> GetMostRecentAsyncById(Func<T, object> orderBy,Expression<Func<T,bool>> filter, Guid id, int take = 3)
    {
        var result = _dbcContext.Set<T>().ToListAsync();

            var filteredResult = result.Result.Where(filter.Compile()).OrderByDescending(orderBy).Take(take).ToList();


        if (result == null)
            return Result<IReadOnlyList<T>>.Failure("No entities found.");

        return Result<IReadOnlyList<T>>.Success(filteredResult);
    }


    public virtual async Task<Result<T>> AddAsync(T entity)
    {
        await _dbcContext.Set<T>().AddAsync(entity);
        await _dbcContext.SaveChangesAsync();
        return Result<T>.Success(entity);
    }

    public virtual async Task<Result<T>> UpdateAsync(T entity)
    {
        _dbcContext.Set<T>().Update(entity);
        await _dbcContext.SaveChangesAsync();
        return Result<T>.Success(entity);
    }

    public Task<Result<IReadOnlyList<T>>> GetAllAsync()
    {
        //get all the entities of type T with all the related entities
        var entities = _dbcContext.Set<T>().AsNoTracking().ToListAsync();
        return Task.FromResult(Result<IReadOnlyList<T>>.Success(entities.Result));
    }

    public virtual async Task<Result<T>> RemoveAsync(T entity)
    {
        _dbcContext.Set<T>().Remove(entity);
        await _dbcContext.SaveChangesAsync();
        return Result<T>.Success(entity);
    }

    public virtual async Task<Result<T>> DeleteAsync(Guid id)
    {
        var entity = await _dbcContext.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return Result<T>.Failure($"Entity with id {id} not found.");
        }

        _dbcContext.Set<T>().Remove(entity);
        await _dbcContext.SaveChangesAsync();
        return Result<T>.Success(entity);
    }

    public virtual async Task<Result<T>> FindByIdAsync(Guid id)
    {
        var entity = await _dbcContext.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return Result<T>.Failure($"Entity with id {id} not found.");
        }

        return Result<T>.Success(entity);
    }

    public virtual async Task<Result<IReadOnlyList<T>>> GetPagedResponseAsync(int page, int size)
    {
        var result = await _dbcContext.Set<T>().Skip(page).Take(size).AsNoTracking().ToListAsync();
        return Result<IReadOnlyList<T>>.Success(result);
    }
}