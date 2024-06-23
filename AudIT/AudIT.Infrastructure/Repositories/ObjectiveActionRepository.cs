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
            Console.WriteLine("The exception occured in the AddActionRisk method in the ObjectiveActionRepository");
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

    /// <summary>
    /// Gets all ObjectiveActions for a given Objective by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Result<List<ObjectiveAction>>> FindAllByObjectiveIdAsync(Guid id)
    {
        var objectiveActions = await _dbcContext.ObjectiveAction
            .Where(o => o.ObjectiveId == id)
            .Include(o => o.ActionRisks)
            .ToListAsync();
        if (objectiveActions.Count == 0)
        {
            return Result<List<ObjectiveAction>>.Failure($"ObjectiveActions for Objective with id {id} not found.");
        }

        return Result<List<ObjectiveAction>>.Success(objectiveActions);
    }

    public async Task<Result<List<ObjectiveAction>>> GetAllSelectedByObjectiveId(Guid requestObjectiveId)
    {
        var objectiveActions = await _dbcContext.ObjectiveAction
            .Where(o => o.ObjectiveId == requestObjectiveId)
            .Where(o => o.Selected == true)
            .Include(o => o.ActionRisks)
            .ToListAsync();

        if (objectiveActions.Count == 0)
        {
            return Result<List<ObjectiveAction>>.Failure(
                $"ObjectiveActions that are selected for auditing for Objective with id {requestObjectiveId} not found.");
        }

        return Result<List<ObjectiveAction>>.Success(objectiveActions);
    }

    public Task<Result<AuditMission>> GetAuditMissionByObjectiveActionId(Guid objectiveActionId)
    {
        var auditMission = _dbcContext.ObjectiveAction
            .Include(o => o.Objective)
            .ThenInclude(x => x.AuditMission)
            .FirstOrDefault(o => o.Id == objectiveActionId)?.Objective.AuditMission;

        if (auditMission == null)
        {
            return Task.FromResult(
                Result<AuditMission>.Failure(
                    $"AuditMission for ObjectiveAction with id {objectiveActionId} not found."));
        }

        return Task.FromResult(Result<AuditMission>.Success(auditMission));
    }



    public async override Task<Result<ObjectiveAction>> FindByIdAsync(Guid id)
    {
        var objectiveAction = _dbcContext.ObjectiveAction
            .Include(o => o.Objective)
            .ThenInclude(x => x.AuditMission)
            .FirstOrDefault(o => o.Id == id);

        if (objectiveAction == null)
        {
            return Result<ObjectiveAction>.Failure($"ObjectiveAction with id {id} not found.");
        }

        return Result<ObjectiveAction>.Success(objectiveAction);
    }
}