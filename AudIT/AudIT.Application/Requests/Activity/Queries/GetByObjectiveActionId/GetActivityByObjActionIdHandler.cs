using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Queries.GetByObjectiveActionId;

public class GetActivityByObjActionIdHandler(
    IActivityRepository activityRepository,
    IMapper mapper
) : IRequestHandler<GetActivityByObjActionIdCommand, BaseDTOResponse<ActivityWithDepartmentDto>>
{
    public async Task<BaseDTOResponse<ActivityWithDepartmentDto>> Handle(GetActivityByObjActionIdCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await activityRepository.GetByObjectiveActionId(request.ActivityId);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<ActivityWithDepartmentDto>("Error while getting activity by ObjectiveActionId", false);
            }

            return new BaseDTOResponse<ActivityWithDepartmentDto>(mapper.Map<List<ActivityWithDepartmentDto>>(result.Value), "Succes",
                true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ActivityWithDepartmentDto>("Error while getting activity by ObjectiveActionId", false);
        }
    }
}