using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Queries.GetByObjectiveActionId;

public class GetActivityByObjActionIdCommand : IRequest<BaseDTOResponse<ActivityWithDepartmentDto>>
{
    public Guid ActivityId { get; set; }

    public GetActivityByObjActionIdCommand(Guid activityId)
    {
        ActivityId = activityId;
    }
}