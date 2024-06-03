using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetAllSelected;

public class GetAllObjActionsCommand : IRequest<BaseDTOResponse<ObjActionWithRisksDto>>
{
    public Guid ObjectiveId { get; set; }

    public GetAllObjActionsCommand(Guid objectiveId)
    {
        ObjectiveId = objectiveId;
    }
}