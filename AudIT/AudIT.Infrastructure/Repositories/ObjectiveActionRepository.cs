using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class ObjectiveActionRepository(AudITContext context):BaseRepository<ObjectiveAction>(context), IObjectiveActionRepository
{

}