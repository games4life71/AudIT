﻿using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Models.Export.Activity;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class ActivityRepository(AudITContext context) : BaseRepository<Activity>(context), IActivityRepository
{
    public async Task<Result<Activity>> AttachDocumentAsync(Guid activityId, BaseDocument document)
    {
        var activity = await FindByWithDocumentsAsync(activityId);

        if (!activity.IsSuccess)
        {
            return new Result<Activity>(false, null, $"Activity with id {activityId} not found");
        }


        if (!activity.Value.AddDocument(document))
            return new Result<Activity>(false, null,
                $"Document with id {document.Id} already attached to activity with id {activityId}");


        await UpdateAsync(activity.Value);
        var result = await _dbcContext.SaveChangesAsync();

        activity = await FindByIdAsync(activityId);

        return new Result<Activity>(true, activity.Value,
            $"Document with id {document.Id} attached to activity with id {activityId}");
    }

    public async Task<Result<Activity>> FindByWithDocumentsAsync(Guid id)
    {
        var activity = await _dbcContext.Activities.Include(a => a.AttachedDocuments)
            .FirstOrDefaultAsync(a => a.Id == id);

        return activity == null
            ? new Result<Activity>(false, null, $"Activity with id {id} not found")
            : new Result<Activity>(true, activity, $"Activity with id {id} found");
    }

    public async Task<Result<Activity>> RemoveDocumentAsync(Guid activityId, Guid documentId)
    {
        var activity = await FindByWithDocumentsAsync(activityId);

        if (!activity.IsSuccess)
        {
            return new Result<Activity>(false, null, $"Activity with id {activityId} not found");
        }

        var document = activity.Value.AttachedDocuments.FirstOrDefault(x => x.Id == documentId);

        if (document == null)
        {
            return new Result<Activity>(false, null, $"Document with id {documentId} not found");
        }

        activity.Value.AttachedDocuments.Remove(document);

        await UpdateAsync(activity.Value);

        var result = await _dbcContext.SaveChangesAsync();

        var updatedActivity = await FindByIdAsync(activityId);

        return new Result<Activity>(true, updatedActivity.Value,
            $"Document with id {documentId} removed from activity with id {activityId}");
    }

    public async Task<Result<ActivityExportModel>> FindByIdForExportAsync(Guid id)
    {
        var activity = await _dbcContext.Activities.Include(a => a.Department)
            .Include(a => a.AuditMission)
            .Include(a => a.ObjectiveAction)
            .Include(a => a.User).Include(activity => activity.AttachedDocuments)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (activity == null)
            return new Result<ActivityExportModel>(false, null, $"Activity with id {id} not found");


        return new Result<ActivityExportModel>(true, new ActivityExportModel(
            activity.Name ?? string.Empty,
            activity.Type.ToString(),
            activity.Department?.Name ?? string.Empty,
            activity.ObjectiveAction?.Name ?? string.Empty,
            activity.AuditMission?.Name ?? string.Empty,
            activity.AttachedDocuments?.Select(d => d.Name).ToList() ?? new List<string>()
        ), null);
    }

    public async Task<Result<List<Activity>>> FindMostRecentByAuditMissionId(Guid requestAuditMissionId)
    {
        var activities = await _dbcContext.Activities
            .Where(a => a.AuditMissionId == requestAuditMissionId)
            .OrderByDescending(a => a.LastModifiedDate)
            .Take(3)
            .ToListAsync();

        if (activities.Count == 0)
            return Result<List<Activity>>.Failure("Cannot find any activities with the given audit mission id");

        return Result<List<Activity>>.Success(activities);
    }

    public async Task<Result<List<Activity>>> FindByAuditMissionId(Guid requestAuditMissionId)
    {
        var activities = await _dbcContext.Activities
            .Where(a => a.AuditMissionId == requestAuditMissionId)
            .ToListAsync();

        return Result<List<Activity>>.Success(activities);
    }
}