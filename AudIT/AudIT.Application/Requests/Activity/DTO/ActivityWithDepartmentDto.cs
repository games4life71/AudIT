using AudIT.Applicationa.Requests.Department.Dto;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.Activity.DTO;

public class ActivityWithDepartmentDto:BaseActivityDto
{
    public ActivityWithDepartmentDto(
        BaseDepartmentDto department,
        Guid id,
        string name,
        ActivityType type,
        Guid departmentId,
        string userId,
        Guid? objectiveActionId = null) : base(id, name, type, departmentId, userId, objectiveActionId)
    {
        Department = department;
    }

    public BaseDepartmentDto Department { get; set; }

}