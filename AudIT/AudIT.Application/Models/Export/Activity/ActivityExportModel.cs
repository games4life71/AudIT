namespace AudIT.Applicationa.Models.Export.Activity;



/// <summary>
/// This class models the data that will be exported for the Activity entity.
///
/// </summary>
public class ActivityExportModel
{

    public string ActivityName { get; set; }

    public string ActivityType { get; set; }

    public string DepartmentName { get; set; }

    public string? ObjectiveActionName { get; set; }

    public string AuditMissionName { get; set; }

    public List<String> AttachedDocuments { get; set; }

    public ActivityExportModel(string activityName, string activityType, string departmentName, string objectiveActionName, string auditMissionName, List<string> attachedDocuments)
    {
        ActivityName = activityName;
        ActivityType = activityType;
        DepartmentName = departmentName;
        ObjectiveActionName = objectiveActionName;
        AuditMissionName = auditMissionName;
        AttachedDocuments = attachedDocuments;
    }
}