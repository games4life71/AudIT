﻿using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class ObjectiveRepository(AudITContext context) : BaseRepository<Objective>(context), IObjectiveRepository
{
    private readonly AudITContext _context = context;

    public async Task<Result<List<Objective>>> FindAllByAuditMissionIdAsync(Guid auditMissionId)
    {
        var objectives = await _context.Objective.Where(o => o.AuditMissionId == auditMissionId).ToListAsync();


        if (objectives.Count == 0)
        {
            return Result<List<Objective>>.Failure($"Objectives for AuditMission with id {auditMissionId} not found.");
        }


        return Result<List<Objective>>.Success(objectives);
    }
}