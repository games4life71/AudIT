using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Queries.GetByAuditMissionId;

public class GetActivitiesByAuditMissionIdHandler(
    IActivityRepository activityRepository,
    IMapper mapper
) : IRequestHandler<GetActivitiesByAuditMissionIdQuery, BaseDTOResponse<BaseActivityDto>>
{
    public async Task<BaseDTOResponse<BaseActivityDto>> Handle(GetActivitiesByAuditMissionIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            if (request.MostRecent)
            {
                var result = await activityRepository.FindMostRecentByAuditMissionId(request.AuditMissionId);

                if (!result.IsSuccess)
                    return new BaseDTOResponse<BaseActivityDto>("Cannot find activities for this audit mission", false);

                return new BaseDTOResponse<BaseActivityDto>(mapper.Map<List<BaseActivityDto>>(result.Value), "Succes",
                    true);
            }

            else
            {
                var result = await activityRepository.FindByAuditMissionId(request.AuditMissionId);

                if (!result.IsSuccess)
                    return new BaseDTOResponse<BaseActivityDto>("Cannot find activities for this audit mission", false);

                return new BaseDTOResponse<BaseActivityDto>(mapper.Map<List<BaseActivityDto>>(result.Value), "Succes",
                    true);
            }
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseActivityDto>(e.Message, false);
        }
    }
}