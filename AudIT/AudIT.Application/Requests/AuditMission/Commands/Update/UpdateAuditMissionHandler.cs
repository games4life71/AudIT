using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Commands.Update;

public class UpdateAuditMissionHandler(
    IAuditMissionRepository auditMissionRepository,
    IMapper mapper
) : IRequestHandler<UpdateAuditMissionCommand, BaseDTOResponse<BaseAuditMissionDto>>
{
    public async Task<BaseDTOResponse<BaseAuditMissionDto>> Handle(UpdateAuditMissionCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var auditMission = await auditMissionRepository.FindByIdAsync(request.Id);
            if (!auditMission.IsSuccess)
            {
                return new BaseDTOResponse<BaseAuditMissionDto>
                {
                    Success = false,
                    Message = $"Audit Mission with id {request.Id} not found"
                };
            }

            auditMission.Value.Update(
                name: request.Name,
                departmentId: request.DepartmentId,
                department: auditMission.Value.Department,
                status:request.Status
            );
            var updateResult = await auditMissionRepository.UpdateAsync(auditMission.Value);


            if (!updateResult.IsSuccess)
            {
                return new BaseDTOResponse<BaseAuditMissionDto>
                {
                    Success = false,
                    Message = $"Audit Mission with id {request.Id} failed to update"
                };
            }

            return new BaseDTOResponse<BaseAuditMissionDto>
            {
                DtoResponse = mapper.Map<BaseAuditMissionDto>(updateResult.Value),
                Success = true,
                Message = "Audit Mission updated successfully"
            };
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>
            {
                Success = false,
                Message = $"Error: {e.Message}"
            };
        }
    }
}