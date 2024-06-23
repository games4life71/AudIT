using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetByRecommendation;

public class GetInstitutionByRecommendationHandler(
    IAuditMissionRecommendationsRepository auditMissionRecommendationsRepository,
    IInstitutionRepository institutionRepository,
    IMapper mapper
) : IRequestHandler<GetInstitutionByRecommendationQuery, BaseDTOResponse<BaseInstitutionDto>>
{
    public async Task<BaseDTOResponse<BaseInstitutionDto>> Handle(GetInstitutionByRecommendationQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var auditMissionRecommendation =
                await auditMissionRecommendationsRepository.GetAuditMissionByRecommendationId(request.RecommendationId);

            if (!auditMissionRecommendation.IsSuccess)
            {
                return new BaseDTOResponse<BaseInstitutionDto>("Audit Mission Recommendation not found", false);
            }

            var institution =
                await institutionRepository.GetInstitutionByAuditMissionId(auditMissionRecommendation.Value
                    .AuditMissionId);

            if (!institution.IsSuccess)
            {
                return new BaseDTOResponse<BaseInstitutionDto>("Institution not found", false);
            }

            return new BaseDTOResponse<BaseInstitutionDto>(mapper.Map<BaseInstitutionDto>(institution.Value), "succes",
                true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseInstitutionDto>(e.Message, false);
        }
    }
}