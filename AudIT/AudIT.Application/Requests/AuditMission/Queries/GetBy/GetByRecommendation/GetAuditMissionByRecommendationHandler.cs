using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByRecommendation;

public class GetAuditMissionByRecommendationHandler(
    IAuditMissionRecommendationsRepository auditMissionRecommendationsRepository,
    IMapper mapper
) : IRequestHandler<GetAuditMissionByRecommendationQuery, BaseDTOResponse<BaseAuditMissionDto>>
{
    public async Task<BaseDTOResponse<BaseAuditMissionDto>> Handle(GetAuditMissionByRecommendationQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var responsse =
                await auditMissionRecommendationsRepository.GetAuditMissionByRecommendationId(request.RecommendationId);

            if (!responsse.IsSuccess)
            {
                return new BaseDTOResponse<BaseAuditMissionDto>("Cannot find audit mission for this recommendation",
                    false);
            }

            var auditMissionDto = mapper.Map<BaseAuditMissionDto>(responsse.Value.AuditMission);

            return new BaseDTOResponse<BaseAuditMissionDto>(auditMissionDto, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>(e.Message, false);
        }
    }
}