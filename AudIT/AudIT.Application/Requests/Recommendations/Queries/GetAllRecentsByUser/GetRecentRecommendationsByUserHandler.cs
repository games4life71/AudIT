using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetAllRecentsByUser;

public class GetRecentRecommendationsByUserHandler(
    IRecommendationRepository recommendationRepository,
    IMapper mapper
) : IRequestHandler<GetRecentRecommendationsByUserQuery, BaseDTOResponse<BaseRecommendationDTO>>
{
    public async Task<BaseDTOResponse<BaseRecommendationDTO>> Handle(GetRecentRecommendationsByUserQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await recommendationRepository.GetMostRecentAsyncById(
                x => x.LastModifiedDate,
                x => x.CreatedBy == request.UserId.ToString(),
                request.UserId,
                5
            );

            if (!response.IsSuccess)
            {
                return new BaseDTOResponse<BaseRecommendationDTO>("No entities found.", false);
            }

            var mappedResult = mapper.Map<List<BaseRecommendationDTO>>(response.Value);

            return new BaseDTOResponse<BaseRecommendationDTO>(mappedResult, "Success", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>(e.Message, false);
        }
    }
}