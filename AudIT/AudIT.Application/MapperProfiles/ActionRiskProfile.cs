using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudiT.Domain.Entities;
using AutoMapper;

namespace AudIT.Applicationa.MapperProfiles;

public class ActionRiskProfile:MyCustomProfile
{
    public ActionRiskProfile()
    {
        CreateMap<ActionRisk, ActionRiskDto>();
    }

}