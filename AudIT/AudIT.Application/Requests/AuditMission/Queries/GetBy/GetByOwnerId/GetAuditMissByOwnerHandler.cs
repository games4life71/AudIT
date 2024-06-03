using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByOwnerId;

public class GetAuditMissByOwnerHandler(IAuditMissionRepository _repository, IMapper _mapper)
    : IRequestHandler<GetAudMissByOwnerId, BaseDTOResponse<AuditMissionWithDateDto>>
{
    public async Task<BaseDTOResponse<AuditMissionWithDateDto>> Handle(GetAudMissByOwnerId request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.GetByOwnerId(request.Id);
            if(!result.IsSuccess)
            {
                return new BaseDTOResponse<AuditMissionWithDateDto>(result.Error, false);
            }
            var mappedResult = _mapper.Map<IEnumerable<AuditMissionWithDateDto>>(result.Value).ToList();
            return new BaseDTOResponse<AuditMissionWithDateDto>(mappedResult, "Success", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<AuditMissionWithDateDto>(e.Message, false);
        }
    }
}