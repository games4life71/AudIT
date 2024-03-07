using AudIT.Applicationa.Requests.Objective.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.Objectives.DTO;

/// <summary>
/// This class models the DTO for an Objective entity
/// It inherits from the BaseObjectiveDto class
/// Adds the ObjectiveAction list to the DTO
/// </summary>
public class ObjectiveCompleteDto : BaseObjectiveDto
{
    public List<ObjectiveAction> ObjectiveActions { get; private set; } = [];

    public ObjectiveCompleteDto(Guid id, string name, Guid auditMissionId, List<ObjectiveAction> objectiveActions) :
        base(id, name, auditMissionId)
    {
        ObjectiveActions = objectiveActions;
    }
}