using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Fiap;

namespace Frontend.Contracts.Abstract_Services.FiapService;

public interface IFiapService
{
    public const string ApiPath = "https://localhost:7248/api/ObjActionFiap";


    public Task<BaseDTOResponse<BaseObjActionFiapViewmodel>> GetRecentFiapsByAudidMissionAsync(Guid audiMissionId);

    public Task<BaseDTOResponse<BaseObjActionFiapViewmodel>> GetFiapsByAudidMissionAsync(Guid audiMissionId);

    public Task<BaseDTOResponse<BaseObjActionFiapViewmodel>> GetFiapByObjectiveActionIdAsync(Guid objectiveActionId);
}