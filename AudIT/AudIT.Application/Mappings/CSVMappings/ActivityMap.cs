using AudIT.Applicationa.Models.Export.Activity;
using AudiT.Domain.Entities;
using CsvHelper.Configuration;

namespace AudIT.Applicationa.Mappings.CSVMappings;

public sealed class ActivityMap : ClassMap<ActivityExportModel>
{   /// <summary>
    /// The order of the columns in this class
    /// HAS to match the order of the CLASS PROPERTIES!!!
    /// </summary>
    public ActivityMap()
    {
        Map(m => m.ActivityName).Name("Activity Name");
        Map(m => m.ActivityType).Name("Activity Type");
        Map(m => m.DepartmentName).Name("Department Name");
        Map(m => m.ObjectiveActionName).Name("Objective Action Name");
        Map(m => m.AuditMissionName).Name("Audit Mission Name");
        // Map(m => m.CreatedBy).Name("CreatedBy");
        // // Map(m => m.CreatedDate).Name("CreatedDate");
        // Map(m => m.AttachedDocuments).Name("AttachedDocuments");
        // Map(m => m.ObjectiveActionId).Ignore();
        // Map(m => m.User).Ignore();
        // // Map(m => m.Department).Ignore();
    }
}