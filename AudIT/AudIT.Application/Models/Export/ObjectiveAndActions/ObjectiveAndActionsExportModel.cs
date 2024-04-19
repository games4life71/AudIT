using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Models.Export.ObjectiveAndActions;

/// <summary>
/// This class models the data that will be exported to a file for the Objective and the corresponding  ObjectiveActions .
/// It is used to export the data as an XLS file later on.
/// This file only contains the data for ONE OBJECTIVE and its corresponding ObjectiveActions
/// </summary>
public class ObjectiveAndActionsExportModel
{
    /// <summary>
    /// Name of the Objective
    /// </summary>
    public string Name { get; private set; }


    /// <summary>
    /// Action Risks for that Objective
    /// </summary>
    public List<ObjectiveAction> ObjectiveActions { get; private set; }

    /// <summary>
    /// The audit mission that the Objective belongs to
    /// </summary>
    public AuditMission AuditMission { get; private set; }

    public ObjectiveAndActionsExportModel(string name, List<ObjectiveAction> objectiveActions,
        AuditMission auditMission)
    {
        Name = name;
        ObjectiveActions = objectiveActions;
        AuditMission = auditMission;
    }
}