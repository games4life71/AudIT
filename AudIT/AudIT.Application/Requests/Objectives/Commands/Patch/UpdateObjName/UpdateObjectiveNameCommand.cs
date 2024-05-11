using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Commands.Patch.UpdateObjName;

public class UpdateObjectiveNameCommand : IRequest<BaseDTOResponse<BaseObjectiveDto>>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}
