using AudIT.Applicationa.Requests.AuditMission.Commands.SetCurrentUserAuditMission.Dto;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class CurrentUserAuditMissionProfile:MyCustomProfile
{

    public CurrentUserAuditMissionProfile()
    {

        CreateMap<CurrentUsersAuditMission, BaseCurrentUserAuditMissionDto>();

    }
}