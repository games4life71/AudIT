using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class ObjectiveActionRepository(AudITContext context)
    : BaseRepository<ObjectiveAction>(context), IObjectiveActionRepository
{
    public async Task<Result<ObjectiveAction>> AddActionRisk(Guid objectiveActionId, ActionRisk actionRisk)
    {
        var objectiveAction = await _dbcContext.Set<ObjectiveAction>().FindAsync(objectiveActionId);
        if (objectiveAction == null)
        {
            return Result<ObjectiveAction>.Failure($"ObjectiveAction with id {objectiveActionId} not found.");
        }

        try
        {
            objectiveAction.ActionRisks.Add(actionRisk);
            await _dbcContext.SaveChangesAsync();
            return Result<ObjectiveAction>.Success(objectiveAction);
        }
        catch (Exception e)
        {
            Console.WriteLine("The execption occured in the AddActionRisk method in the ObjectiveActionRepository");
            throw;
        }
    }

    public async Task<Result<ObjectiveAction>> FindByIdAsyncWithActionRisks(Guid id)
    {
        var objectiveAction = await _dbcContext.ObjectiveAction
            .Include(o => o.ActionRisks)
            .FirstOrDefaultAsync(o => o.Id == id);
        if (objectiveAction == null)
        {
            return Result<ObjectiveAction>.Failure($"ObjectiveAction with id {id} not found.");
        }

        return Result<ObjectiveAction>.Success(objectiveAction);
    }
}