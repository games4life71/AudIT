using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetAllByAuditMission;

public class GetRecommendationsByAuditMissionHandler(
    IAuditMissionRecommendationsRepository auditMissionRecommendationsRepository,
    IMapper mapper
) : IRequestHandler<GetRecommendationsByAuditMissionCommand, BaseDTOResponse<BaseRecommendationDTO>>
{
    public async Task<BaseDTOResponse<BaseRecommendationDTO>> Handle(GetRecommendationsByAuditMissionCommand request,
        CancellationToken cancellationToken)
    {
        //this method returns a list of recommendations for a given audit mission
        try
        {
            var auditMissionRecommendations =
                await auditMissionRecommendationsRepository.FindAllByAuditMissionIdAsync(request.AuditMissionId);

            if (!auditMissionRecommendations.IsSuccess)
            {
                return new BaseDTOResponse<BaseRecommendationDTO>("No recommendations found", false);
            }


            return new BaseDTOResponse<BaseRecommendationDTO>(
                mapper.Map<List<BaseRecommendationDTO>>(auditMissionRecommendations.Value), "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>($"An error occured: {e.Message}", false);
        }
    }
}