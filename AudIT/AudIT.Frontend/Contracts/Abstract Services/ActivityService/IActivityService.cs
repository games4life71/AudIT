using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Activity;

namespace Frontend.Contracts.Abstract_Services.ActivityService;

public interface IActivityService
{
    public const string ApiPath = "https://localhost:7248/api/v1/Activity";

    public Task<BaseDTOResponse<BaseActivityViewmodel>> GetActivitiesByAuditMissionIdAsync(Guid auditMissionId);
    public Task<BaseDTOResponse<BaseActivityViewmodel>> GetRecentActivitiesByAuditMissionIdAsync(Guid auditMissionId);

    public Task<BaseDTOResponse<ActivityWithDepartViewModel>> GetActivitiesByObjectiveActionIdAsync(Guid objectiveActionId);


}