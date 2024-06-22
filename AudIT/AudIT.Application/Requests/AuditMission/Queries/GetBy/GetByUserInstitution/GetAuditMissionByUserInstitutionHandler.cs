using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByUserInstitution;

public class GetAuditMissionByUserInstitutionHandler(
    IUserInstitutionRepository userInstitutionRepository,
    IAuditMissionRepository auditMissionRepository,
    IMapper mapper
) : IRequestHandler<GetAuditMissionByUserInstitutionCommand, BaseDTOResponse<AuditMissionWithDateDto>>
{
    public async Task<BaseDTOResponse<AuditMissionWithDateDto>> Handle(GetAuditMissionByUserInstitutionCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var userInstitution = await userInstitutionRepository.GetInstitutionByUserId(Guid.Parse(request.UserId));

            if (!userInstitution.IsSuccess)
            {
                return new BaseDTOResponse<AuditMissionWithDateDto>
                {
                    Message = $"User institution not found for user id {request.UserId}",
                    Success = false
                };
            }


            //get all the audit missions for the user institution

            var auditMissions = await auditMissionRepository.GetByInstitutionId(userInstitution.Value.Id);

            if (!auditMissions.IsSuccess)
            {
                return new BaseDTOResponse<AuditMissionWithDateDto>
                {
                    Message = "No audit mission found for this user institution",
                    Success = false
                };
            }

            var auditMissionWithDateDtos = mapper.Map<List<AuditMissionWithDateDto>>(auditMissions.Value);

            return new BaseDTOResponse<AuditMissionWithDateDto>(auditMissionWithDateDtos,
                "Audit missions found successfully ", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<AuditMissionWithDateDto>
            {
                Message = "Error: " + e.Message,
                Success = false
            };
        }
    }
}