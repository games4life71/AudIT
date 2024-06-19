using Frontend.Contracts.Services;

namespace Frontend.Services.AppServices;

public class CurrentUserChangedMissionService:ICurrentUserChangedMissionService
{
    public event Action? CurrentUserChangedMission;

    public void NotifyCurrentUserChangedMission()
    {
        Console.WriteLine("NotifyCurrentUserChangedMission is called");
        CurrentUserChangedMission?.Invoke();
    }
}