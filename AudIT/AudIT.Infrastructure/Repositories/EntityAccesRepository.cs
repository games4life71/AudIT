using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class EntityAccesRepository : BaseRepository<EntityAcces>, IEntityAccesRepository
{
    private readonly AudITContext _context;

    public EntityAccesRepository(AudITContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Result<EntityAcces>> FindByEntityIdAsync(Guid entityId, EntityType entityType)
    {
        var entityAcces =
            await _context.EntityAcces.FirstOrDefaultAsync(x => x.EntityId == entityId && x.Type == entityType);

        if (entityAcces == null)
        {
            return Result<EntityAcces>.Failure("Entity acces not found");
        }

        return Result<EntityAcces>.Success(entityAcces);
    }

    public async  Task<Result<List<EntityAcces>>> GetAllByUserId(Guid requestUserId)
    {

        var entityAcces = await _context.EntityAcces
            .Where(x=>x.UserId == requestUserId.ToString())
            .ToListAsync();


        if (!entityAcces.Any())
        {
            return Result<List<EntityAcces>>.Failure("Entity acces not found");
        }

        return Result<List<EntityAcces>>.Success(entityAcces);
    }
}