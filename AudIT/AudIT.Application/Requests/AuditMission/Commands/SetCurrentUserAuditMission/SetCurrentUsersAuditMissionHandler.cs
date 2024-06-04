using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.Commands.SetCurrentUserAuditMission.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Commands.SetCurrentUserAuditMission;

public class SetCurrentUsersAuditMissionHandler(
    ICurrentUserAuditMissioRepo _currentUserAuditMissioRepo,
    IMapper mapper
) : IRequestHandler<SetCurrentUsersAuditMissionCommand, BaseDTOResponse<BaseCurrentUserAuditMissionDto>>
{
    public async Task<BaseDTOResponse<BaseCurrentUserAuditMissionDto>> Handle(
        SetCurrentUsersAuditMissionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result =
                await _currentUserAuditMissioRepo.SetCurrentUserAuditMissionAsync(request.UserId,
                    request.AuditMissionId);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseCurrentUserAuditMissionDto>(
                    "Failed to set the current user's audit mission.", false);
            }


            return new BaseDTOResponse<BaseCurrentUserAuditMissionDto>(
                mapper.Map<BaseCurrentUserAuditMissionDto>(result.Value), "succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseCurrentUserAuditMissionDto>(e.Message, false);
        }
    }
}