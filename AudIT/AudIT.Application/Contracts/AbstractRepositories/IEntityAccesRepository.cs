﻿using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IEntityAccesRepository:IRepository<EntityAcces>
{

    public Task<Result<EntityAcces>> FindByEntityIdAsync(Guid entityId, EntityType entityType);

    public Task<Result<List<EntityAcces>>> GetAllByUserId(Guid requestUserId);
}