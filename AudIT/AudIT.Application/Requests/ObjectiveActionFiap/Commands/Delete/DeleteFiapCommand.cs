using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Delete;

public class DeleteFiapCommand:IRequest<BaseResponse>
{

    public Guid FiapId { get; set; }

    public DeleteFiapCommand(Guid fiapId)
    {
        FiapId = fiapId;
    }
}