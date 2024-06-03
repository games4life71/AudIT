using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Requests.Objectives.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class ObjectiveProfile : MyCustomProfile
{
    public ObjectiveProfile()
    {
        CreateMap<Objective, BaseObjectiveDto>();
        CreateMap<Objective, ObjectiveCompleteDto>();
    }
}