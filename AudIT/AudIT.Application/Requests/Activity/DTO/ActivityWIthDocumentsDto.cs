using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Requests.Activity.DTO;

public class ActivityWIthDocumentsDto : BaseActivityDto
{
    public List<BaseDocument> AttachedDocuments { get; set; }

    public ActivityWIthDocumentsDto(Guid id, string name, ActivityType type, Guid departmentId, string userId,
        List<BaseDocument> attachedDocuments,Guid? ObjectiveActionId = null) : base(id, name, type, departmentId, userId, ObjectiveActionId)
    {
        AttachedDocuments = attachedDocuments;
    }
}