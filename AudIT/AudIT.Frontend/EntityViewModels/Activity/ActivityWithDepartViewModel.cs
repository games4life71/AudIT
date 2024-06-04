using Frontend.EntityDtos.Department;

namespace Frontend.EntityViewModels.Activity;

public class ActivityWithDepartViewModel : BaseActivityViewmodel
{
    public BaseDepartmentDto Department { get; set; }

    public ActivityWithDepartViewModel(BaseDepartmentDto department, Guid id, string name, ActivityType type,
        Guid departmentId, string userId, Guid? objectiveActionId = null) : base(id, name, type, departmentId, userId,
        objectiveActionId)
    {
        Department = department;
    }
}