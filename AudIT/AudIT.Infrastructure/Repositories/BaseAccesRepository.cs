using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Domain.Misc;

namespace AudIT.Infrastructure.Repositories;

public class BaseAccesRepository<TEntity> : IRepositoryAcces<TEntity> where TEntity : AuditableEntity
{
    private readonly AudITContext _context;

    public BaseAccesRepository(AudITContext context)
    {
        _context = context;
    }


    public async Task<Result<TEntity>> SetWriteAccesAsync(Guid userId, Guid entityId)
    {
        var entity = await _context.Set<TEntity>().FindAsync(entityId);

        if (entity == null)
        {
            return Result<TEntity>.Failure("Entity not found.");
        }

        entity.WriteAccesUserId ??= [];

        entity.WriteAccesUserId?.Add(userId);

        await _context.SaveChangesAsync();

        return Result<TEntity>.Success(entity);
    }

    public async Task<Result<TEntity>> SetReadAccesAsync(Guid userId, Guid entityId)
    {
        var entity = await _context.Set<TEntity>().FindAsync(entityId);

        if (entity == null)
        {
            return Result<TEntity>.Failure("Entity not found.");
        }

        entity.ReadAccesUserId ??= [];

        entity.ReadAccesUserId?.Add(userId);

        await _context.SaveChangesAsync();

        return Result<TEntity>.Success(entity);
    }
}