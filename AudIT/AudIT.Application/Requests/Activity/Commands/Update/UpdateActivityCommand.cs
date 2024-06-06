using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Commands.Update;

public class UpdateActivityCommand : IRequest<BaseDTOResponse<ActivityWithDepartmentDto>>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ActivityType Type { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid AuditMissionId { get; set; }

    public Guid? ObjectiveActionId { get; set; }
}