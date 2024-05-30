namespace Frontend.EntityDtos.AuditMission;

public class AuditMissionWithDepartmentName(
    Guid id,
    string name,
    string userId,
    Guid departmentId,
    string? departmentName,
    DateTime lastModifiedDate
    )
{
    public Guid Id { get; set; } = id;

    public string Name { get; set; } = name;

    public string UserId { get; set; } = userId;

    public Guid DepartmentId { get; set; } = departmentId;

    public string? DepartmentName { get; set; } = departmentName;

    public AuditMissionStatus Status { get; set; } = AuditMissionStatus.Creata;

    public DateTime LastModifiedDate { get; set; } = lastModifiedDate;
}