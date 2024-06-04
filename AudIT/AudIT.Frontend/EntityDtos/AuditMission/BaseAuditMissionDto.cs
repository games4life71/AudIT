using System.Runtime.InteropServices.JavaScript;

namespace Frontend.EntityDtos.AuditMission;

public class BaseAuditMissionDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string UserId { get; set; }

    public Guid DepartmentId { get; set; }

    public AuditMissionStatus Status { get; set; } = AuditMissionStatus.Creata;

    public DateTime LastModifiedDate { get; set; }
    public BaseAuditMissionDto(Guid id, string? name, string userId, Guid departmentId, AuditMissionStatus status, DateTime lastModifiedDate)
    {
        Id = id;
        Name = name;
        UserId = userId;
        DepartmentId = departmentId;
        Status = status;
        LastModifiedDate = lastModifiedDate;
    }

    public BaseAuditMissionDto()
    {

    }

}

public enum AuditMissionStatus
{
    Creata,
    PregatireaMisiunii,
    InterventiaLaFataLocului,
    RezultateleMisiunii,
    UrmarireaRecomandarilor,
    Finalizata,
    Arhivata,
    Anulata
}