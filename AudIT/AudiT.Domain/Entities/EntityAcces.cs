using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

public class EntityAcces
{
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public string GrantedByUserId { get; set; }

    public User GrantedByUser { get; set; }

    public User User { get; set; }


    public Guid EntityId { get; set; }

    public EntityType Type { get; set; }

    public AccesType AccesType { get; set; }



    private EntityAcces(string userId,  Guid entityId, EntityType entityType, AccesType accesType, string grantedByUserId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        EntityId = entityId;
        Type = entityType;
        AccesType = accesType;
        GrantedByUserId = grantedByUserId;
    }



    public static Result<EntityAcces> Create(string userId, Guid entityId, EntityType entityType, AccesType accesType, string grantedByUserId)
    {
        return Result<EntityAcces>.Success(new EntityAcces(userId, entityId, entityType, accesType, grantedByUserId));
    }



    public EntityAcces()
    {

    }

}

public enum EntityType
{
    Activity,
    AuditMission,
    Department,
    Institution,
    Objective,
    ObjectiveAction,
    ObjectiveActionFiap,
    Recommendation,
    StandaloneDocument,
    TemplateDocument
}

public enum AccesType
{
    Read,
    Write
}