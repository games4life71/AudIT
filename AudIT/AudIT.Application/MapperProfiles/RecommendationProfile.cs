using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class RecommendationProfile:MyCustomProfile
{

    public RecommendationProfile()
    {

        CreateMap<Recommendation,BaseRecommendationDTO>();


    }


}