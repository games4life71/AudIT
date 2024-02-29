using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Commands.Create;

public class CreateBaseObjActionCommand : IRequest<BaseDTOResponse<BaseObjActionDto>>
{
    public string Name { get; set; }

    public Guid ObjectiveId { get; set; }

    public CreateBaseObjActionCommand(string name, Guid objectiveId)
    {
        Name = name;
        ObjectiveId = objectiveId;
    }
}