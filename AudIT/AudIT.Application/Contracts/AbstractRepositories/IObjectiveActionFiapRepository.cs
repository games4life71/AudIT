﻿using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IObjectiveActionFiapRepository:IRepository<ObjectiveActionFiap>
{
    Task<Result<List<ObjectiveActionFiap>>> GetAllByObjActionId(Guid requestObjectiveActionId);
}