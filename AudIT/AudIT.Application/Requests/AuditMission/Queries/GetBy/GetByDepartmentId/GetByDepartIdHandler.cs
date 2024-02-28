using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByDepartmentId;

public class GetByDepartIdHandler(IAuditMissionRepository _repo, IMapper _mapper)
    : IRequestHandler<GetByDepartIdQuery, BaseDTOResponse<BaseAuditMissionDto>>
{
    public async Task<BaseDTOResponse<BaseAuditMissionDto>> Handle(GetByDepartIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repo.GetByDepartmentId(request.DepartmentId);

        if (!result.IsSuccess)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("Error: " + result.Error, false);
        }

        var auditMissionDtos = _mapper.Map<IReadOnlyList<BaseAuditMissionDto>>(result.Value);

        return new BaseDTOResponse<BaseAuditMissionDto>(auditMissionDtos.ToList(), "Audit missions found", true);
    }
}