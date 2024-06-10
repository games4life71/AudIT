using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.ObjectiveAction;
using Frontend.EntityViewModels.Objective;
using Frontend.EntityViewModels.ObjectiveAction;

namespace Frontend.Contracts.Abstract_Services.ObjectiveActionService;

public interface IObjectiveActionService
{

    public const string ApiPath = "https://localhost:7248/api/v1/ObjectiveAction";

    public Task<BaseDTOResponse<BaseObjectiveActionViewModel>> CreateObjectiveActionAsync(CreateObjectiveActionDto createObjectiveActionDto);


    public Task<BaseDTOResponse<BaseObjectiveActionViewModel>> UpdateObjActionControlsSelectedAsync(UpdateObjActionControlsSelectedDto updateObjActionControlsSelectedDto);

    public Task<BaseDTOResponse<ObjectiveActionViewModel>> GetObjectiveActionByIdAsync(Guid id);

    public Task<BaseDTOResponse<ObjectiveActionViewModel>> GetObjectiveActionByObjectiveIdAsync(Guid id);
}