using AudIT.Applicationa.Requests.Activity.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class ActivityProfile:MyCustomProfile
{
    public ActivityProfile()
    {

        CreateMap<Activity, BaseActivityDto>();
        CreateMap<Activity, ActivityWIthDocumentsDto>()
            .ForMember(dest => dest.AttachedDocuments, opt => opt.MapFrom(src => src.AttachedDocuments));

    }

    
}