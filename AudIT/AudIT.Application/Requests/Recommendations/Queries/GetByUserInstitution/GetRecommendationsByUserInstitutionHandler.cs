using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetByUserInstitution;

public class GetRecommendationsByUserInstitutionHandler(
    IUserInstitutionRepository userInstitutionRepository,
    IRecommendationRepository recommendationRepository,
    IAuditMissionRecommendationsRepository auditMissionRecommendationsRepository,
    IMapper mapper
) : IRequestHandler<GetRecommendationsByUserInstitution, BaseDTOResponse<BaseRecommendationDTO>>
{
    public async Task<BaseDTOResponse<BaseRecommendationDTO>> Handle(GetRecommendationsByUserInstitution request,
        CancellationToken cancellationToken)
    {
        // Get the user institution

        var userInstitution = await userInstitutionRepository.GetUserInstitutionByUserId(request.UserId);

        if (!userInstitution.IsSuccess)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>
            {
                Success = false,
                Message = $"Cannot find user institution for user with id {request.UserId}"
            };
        }

        throw new NotImplementedException();
    }
}