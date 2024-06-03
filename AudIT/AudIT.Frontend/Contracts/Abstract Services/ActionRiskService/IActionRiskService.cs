using Frontend.EntityDtos.ActionRisk;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.ActionRisk;
using Frontend.EntityViewModels.ObjectiveAction;

namespace Frontend.Contracts.Abstract_Services.ActionRiskService;

public interface IActionRiskService
{

    public const string ApiPath = "https://localhost:7248/api/v1/ObjectiveAction";

    public Task<BaseDTOResponse<ActionRiskViewModel>> UpdateActionRisk(UpdateActionRiskDto updateActionRiskDto);

    public Task<BaseDTOResponse<ObjActionWithRisksViewModel>> CreateActionRiskAsync(CreateActionRiskDto createActionRiskDto);

    Task<BaseResponse> DeleteActionRiskAsync(Guid actionRiskId);
}