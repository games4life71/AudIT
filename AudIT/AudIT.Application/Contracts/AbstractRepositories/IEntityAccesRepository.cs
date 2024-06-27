using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IEntityAccesRepository:IRepository<EntityAcces>
{

    public Task<Result<EntityAcces>> FindByEntityIdAsync(Guid entityId, EntityType entityType, string userId);

    public Task<Result<List<EntityAcces>>> GetAllByUserId(Guid requestUserId);
    public Task<Result<List<EntityAcces>>> GetAllGrantedAccesByUserId(Guid requestUserId);
}