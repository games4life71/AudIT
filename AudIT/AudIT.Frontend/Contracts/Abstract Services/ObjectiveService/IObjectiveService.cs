﻿using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.Objective;
using Frontend.EntityViewModels.Objective;

namespace Frontend.Contracts.Abstract_Services.ObjectiveService;

public interface IObjectiveService
{
    public const string ApiPath = "https://localhost:7248/api/v1/Objective";

    public Task<BaseDTOResponse<BaseObjectiveViewModel>> GetMostRecentObjectiveByAuditMissionIdAsync(
        Guid auditMissionId);

    public Task<BaseDTOResponse<BaseObjectiveViewModel>> GetObjectivesByAuditMissionIdAsync(Guid auditMissionId);

    public Task<BaseDTOResponse<ObjectiveFullViewModel>> GetObjectiveWithActionsByIdAsync(Guid objectiveId);

    public Task<BaseDTOResponse<ObjectiveFullViewModel>> GetObjectiveFullByAuditMissionIdAsync(
        Guid auditMissionId);

    public Task<BaseDTOResponse<BaseObjectiveViewModel>> GetObjectiveByRecommendationIdAsync(Guid recommendationId);

    public  Task<BaseResponse> DeleteObjectiveAsync(Guid  objectiveId);
    public  Task<BaseDTOResponse<BaseObjectiveViewModel>> UpdateObjectiveAsync(UpdateObjectiveNameDto updateObjectiveNameDto);
    public Task<BaseDTOResponse<BaseObjectiveViewModel>> CreateObjectiveAsync(CreateObjectiveDto createObjectiveDto);
}