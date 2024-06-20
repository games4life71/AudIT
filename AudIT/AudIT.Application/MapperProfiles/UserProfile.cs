using AudIT.Applicationa.Requests.User.Dto;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class UserProfile : MyCustomProfile
{
    public UserProfile()
    {
        CreateMap<User, BaseUserInformationDto>() .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName));
    }
}