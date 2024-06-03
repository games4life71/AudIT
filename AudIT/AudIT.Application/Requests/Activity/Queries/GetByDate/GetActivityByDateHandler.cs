using System.Linq.Expressions;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Queries.GetByDate;

public class GetActivityByDateHandler(
    IActivityRepository activityRepository,
    IMapper mapper
) : IRequestHandler<GetActivityByDateCommand, BaseDTOResponse<ActivityWIthDocumentsDto>>
{
    public async Task<BaseDTOResponse<ActivityWIthDocumentsDto>> Handle(GetActivityByDateCommand request,
        CancellationToken cancellationToken)
    {
        //create a new exprresion to filter the activities by date
        Expression<Func<AudiT.Domain.Entities.Activity, bool>> filter = activity =>
            activity.CreatedDate >= request.StartDate && activity.LastModifiedDate <= request.EndDate;

        var result = await activityRepository.GetByFilterAsync(filter);


        if (!result.IsSuccess)
        {
            return new BaseDTOResponse<ActivityWIthDocumentsDto>("No activities found for the specified date range.",
                false);
        }

        var mappedResults = mapper.Map<List<ActivityWIthDocumentsDto>>(result.Value);

        return new BaseDTOResponse<ActivityWIthDocumentsDto>(mappedResults, "Activities retrieved successfully", true);
    }
}