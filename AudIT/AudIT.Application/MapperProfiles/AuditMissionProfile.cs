using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class AuditMissionProfile:MyCustomProfile
{

    public AuditMissionProfile()
    {
        CreateMap<AuditMission, BaseAuditMissionDto>();
        CreateMap<AuditMission,IReadOnlyList<AuditMission>>();
        CreateMap<AuditMission, AuditMissionWithDateDto>();
    }

}