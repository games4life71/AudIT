using AudIT.Applicationa.Requests.EntityAcces.Commands.Create;
using AudIT.Applicationa.Requests.EntityAcces.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class EntityAccesProfile:MyCustomProfile
{
    public EntityAccesProfile()
    {
        CreateMap<EntityAcces, BaseEntityAccesDto>();
        CreateMap<EntityAcces, EntityAccesWithUserInfo>();

    }
}