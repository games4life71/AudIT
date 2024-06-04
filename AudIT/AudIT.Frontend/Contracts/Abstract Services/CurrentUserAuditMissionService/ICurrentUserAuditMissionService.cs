using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.CurrentUserAuditMissionViewModel;

namespace Frontend.Contracts.Abstract_Services.CurrentUserAuditMissionService;

public interface ICurrentUserAuditMissionService
{

    public const string ApiPath = "https://localhost:7248/api/v1/AuditMission";
    public Task<BaseDTOResponse<CurrentUserAuditMissionViewModel>> GetCurrentUserAuditMissionAsync();


}