using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.Commands.SetCurrentUserAuditMission.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.GetCurrentUserAuditMission;

public class GetCurrentUserAuditMIssionHAndler(
    ICurrentUserAuditMissioRepo currentUserAuditMissioRepo,
    IMapper mapper
) : IRequestHandler<GetCurrentUserAuditMissionQuery, BaseDTOResponse<BaseCurrentUserAuditMissionDto>>
{
    public async Task<BaseDTOResponse<BaseCurrentUserAuditMissionDto>> Handle(GetCurrentUserAuditMissionQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await currentUserAuditMissioRepo.GetCurrentUserAuditMissionAsync(request.UserId);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseCurrentUserAuditMissionDto>(
                    $"Failed to get current user audit mission for user {request.UserId}", false);
            }


            return new BaseDTOResponse<BaseCurrentUserAuditMissionDto>(
                mapper.Map<BaseCurrentUserAuditMissionDto>(result.Value), "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseCurrentUserAuditMissionDto>(
                $"An error occured while getting current user audit mission for user {request.UserId}", false);
        }
    }
}