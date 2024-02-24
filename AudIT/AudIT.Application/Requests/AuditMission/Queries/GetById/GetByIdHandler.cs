using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetById;

public class GetByIdHandler(IAuditMissionRepository _auditMissionRepository, IMapper _mapper)
    : IRequestHandler<GetByIdQuery, BaseDTOResponse<BaseAuditMissionDto>>
{
    public async Task<BaseDTOResponse<BaseAuditMissionDto>> Handle(GetByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var auditMission = await _auditMissionRepository.FindByIdAsync(request.Id);

            if (!auditMission.IsSuccess)
            {
                return new BaseDTOResponse<BaseAuditMissionDto>("Audit mission not found", false);
            }

            return new BaseDTOResponse<BaseAuditMissionDto>(_mapper.Map<BaseAuditMissionDto>(auditMission.Value),
                "Audit mission found", true);
        }


        catch (Exception e)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>(e.Message, false);
        }
    }
}