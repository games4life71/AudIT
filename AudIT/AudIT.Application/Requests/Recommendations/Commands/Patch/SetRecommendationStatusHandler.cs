using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Commands.Patch;

public class SetRecommendationStatusHandler(
    IRecommendationRepository recommendationRepository,
    IMapper mapper
) : IRequestHandler<SetRecommendationStatusCommand, BaseDTOResponse<BaseRecommendationDTO>>
{
    public async Task<BaseDTOResponse<BaseRecommendationDTO>> Handle(SetRecommendationStatusCommand request,
        CancellationToken cancellationToken)
    {
        var result = await recommendationRepository.UpdateStatusAsync(request.Id, request.Status);

        if (!result.IsSuccess)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>(result.Error,false);
        }


        return new BaseDTOResponse<BaseRecommendationDTO>(mapper.Map<BaseRecommendationDTO>(result.Value),"Recommendation status updated successfully",true);


    }
}