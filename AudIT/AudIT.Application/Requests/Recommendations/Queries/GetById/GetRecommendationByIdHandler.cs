using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetById;

public class GetRecommendationByIdHandler(
    IRecommendationRepository recommendationRepository,
    IMapper mapper
) : IRequestHandler<GetRecommendationById, BaseDTOResponse<BaseRecommendationDTO>>
{
    public async Task<BaseDTOResponse<BaseRecommendationDTO>> Handle(GetRecommendationById request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await recommendationRepository.FindByIdWithObjectiveActionAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseRecommendationDTO>("Recommendation not found", false);
            }


            return new BaseDTOResponse<BaseRecommendationDTO>(mapper.Map<BaseRecommendationDTO>(result.Value));
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>(e.Message, false);
        }
    }
}