namespace Frontend.Contracts.Services;

public interface ICurrentUserChangedMissionService
{
    event Action CurrentUserChangedMission;

    void NotifyCurrentUserChangedMission();

}