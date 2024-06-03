using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class ObjectiveActionFiapProfile : MyCustomProfile
{
    public ObjectiveActionFiapProfile()
    {
        CreateMap<ObjectiveActionFiap, BaseObjActionFiapDto>();
    }
}