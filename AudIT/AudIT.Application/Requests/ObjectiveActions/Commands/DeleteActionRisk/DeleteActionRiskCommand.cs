using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Commands.DeleteActionRisk;

public class DeleteActionRiskCommand:IRequest<BaseResponse>
{
    public Guid Id { get; set; }

    public DeleteActionRiskCommand(Guid id)
    {
        Id = id;
    }
}