using AudiT.Domain.Entities;
using CsvHelper.Configuration;

namespace AudIT.Applicationa.Mappings.CSVMappings;

public sealed class ActivityMap : ClassMap<Activity>
{   /// <summary>
    /// The order of the columns in this class
    /// HAS to match the order of the CLASS PROPERTIES!!!
    /// </summary>
    public ActivityMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.Name).Name("Name");
        Map(m => m.Type).Name("Type");
        Map(m => m.DepartmentId).Name("DepartmentId");
        Map(m => m.AuditMissionId).Name("Audit Mission Id");
        // Map(m => m.CreatedBy).Name("CreatedBy");
        // // Map(m => m.CreatedDate).Name("CreatedDate");
        // Map(m => m.AttachedDocuments).Name("AttachedDocuments");
        // Map(m => m.ObjectiveActionId).Ignore();
        // Map(m => m.User).Ignore();
        // // Map(m => m.Department).Ignore();
    }
}