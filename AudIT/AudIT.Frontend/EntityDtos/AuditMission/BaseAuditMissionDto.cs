namespace Frontend.EntityDtos.AuditMission;

public class BaseAuditMissionDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string UserId { get; set; }

    public Guid DepartmentId { get; set; }

    public BaseAuditMissionDto(Guid id, string? name, string userId, Guid departmentId)
    {
        Id = id;
        Name = name;
        UserId = userId;
        DepartmentId = departmentId;
    }


}