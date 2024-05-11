using AudIT.Applicationa.Requests.Objectives.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Commands.Patch.RemoveObjectiveAction;

public class RemoveObjActionCommand : IRequest<BaseDTOResponse<ObjectiveCompleteDto>>
{
    public Guid ObjectiveId { get; set; }

    public Guid ObjectiveActionId { get; set; }

    public RemoveObjActionCommand(Guid objectiveId, Guid objectiveActionId)
    {
        ObjectiveId = objectiveId;
        ObjectiveActionId = objectiveActionId;
    }
}