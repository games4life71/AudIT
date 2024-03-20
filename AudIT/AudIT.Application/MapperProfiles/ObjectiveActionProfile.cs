using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class ObjectiveActionProfile : MyCustomProfile
{
    public ObjectiveActionProfile()
    {
        CreateMap<BaseObjActionDto, ObjectiveAction>();
        CreateMap<ObjectiveAction, BaseObjActionDto>();
        CreateMap<ObjectiveAction, ObjActionWithRisksDto>();
        CreateMap<ObjActionWithRisksDto, ObjectiveAction>();

    }
}