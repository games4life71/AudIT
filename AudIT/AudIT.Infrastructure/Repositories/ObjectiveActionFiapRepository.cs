using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class ObjectiveActionFiapRepository : BaseRepository<ObjectiveActionFiap>, IObjectiveActionFiapRepository
{
    public ObjectiveActionFiapRepository(AudITContext context) : base(context)
    {
    }


    public override async Task<Result<ObjectiveActionFiap>> FindByIdAsync(Guid id)
    {
        var result = await _dbcContext.ObjectiveActionFiap
            .Include(a => a.AuditMission)
            .Include(a => a.ObjectiveAction)

            .FirstOrDefaultAsync(a => a.Id == id);

        if(result == null)
            return Result<ObjectiveActionFiap>.Failure($"Cannot find ObjectiveActionFiap with id {id}");
        return Result<ObjectiveActionFiap>.Success(result);

    }
}