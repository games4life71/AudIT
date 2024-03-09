using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByOwnerId;

public class GetAuditMissByOwnerHandler(IAuditMissionRepository _repository, IMapper _mapper)
    : IRequestHandler<GetAudMissByOwnerId, BaseDTOResponse<BaseAuditMissionDto>>
{
    public async Task<BaseDTOResponse<BaseAuditMissionDto>> Handle(GetAudMissByOwnerId request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.GetByOwnerId(request.Id);
            var mappedResult = _mapper.Map<IEnumerable<BaseAuditMissionDto>>(result.Value).ToList();
            return new BaseDTOResponse<BaseAuditMissionDto>(mappedResult, "Success", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>(e.Message, false);
        }
    }
}