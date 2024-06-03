using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Queries;

public class GetActivityByIdHandler(
    IActivityRepository activityRepository,
    IMapper mapper
) : IRequestHandler<GetActivityByIdQuery, BaseDTOResponse<ActivityWIthDocumentsDto>>
{
    public async Task<BaseDTOResponse<ActivityWIthDocumentsDto>> Handle(GetActivityByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var activity = await activityRepository.FindByWithDocumentsAsync(request.Id);


            if (!activity.IsSuccess)
            {
                return new BaseDTOResponse<ActivityWIthDocumentsDto>($"Activity with id {request.Id} not found", false);
            }

            return new BaseDTOResponse<ActivityWIthDocumentsDto>(mapper.Map<ActivityWIthDocumentsDto>(activity.Value),
                "Successfully retrieved activity", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ActivityWIthDocumentsDto>($"An error occurred: {e.Message}", false);
        }
    }
}