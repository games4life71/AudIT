using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class ObjectiveRepository(AudITContext context) : BaseRepository<Objective>(context), IObjectiveRepository
{
    private readonly AudITContext _context = context;

    public async Task<Result<List<Objective>>> FindAllByAuditMissionIdAsync(Guid auditMissionId)
    {
        var objectives = await _context.Objective
            .Where(o => o.AuditMissionId == auditMissionId)
            .ToListAsync();


        if (objectives.Count == 0)
        {
            return Result<List<Objective>>.Failure($"Objectives for AuditMission with id {auditMissionId} not found.");
        }


        return Result<List<Objective>>.Success(objectives);
    }

    /// <summary>
    /// Get the most recent 3  objectives by audit mission id
    /// </summary>
    /// <param name="auditMissionId"></param>
    /// <returns></returns>
    public async Task<Result<List<Objective>>> FindMostRecentsByAuditMissionIdAsync(Guid auditMissionId)
    {
        var result = await context.Objective
            .Where(o => o.AuditMissionId == auditMissionId)
            .OrderByDescending(o => o.LastModifiedDate)
            .Take(3)
            .ToListAsync();

        if (result.Count == 0)
        {
            return Result<List<Objective>>.Failure($"Objectives for AuditMission with id {auditMissionId} not found.");
        }

        return Result<List<Objective>>.Success(result);
    }

    public override async Task<Result<Objective>> FindByIdAsync(Guid id)
    {
        var objective = await _context.Objective.Include(o => o.ObjectiveActions).FirstOrDefaultAsync(o => o.Id == id);


        if (objective != null) return Result<Objective>.Success(objective);

        return Result<Objective>.Failure($"Objective with id {id} not found.");
    }
}