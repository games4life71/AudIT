using AudiT.Domain.Entities;

namespace AudIT.Domain.Misc;

public class EntityUserAccess<T> where T : AuditableEntity
{
    public Guid Id { get; set; }
    public string UserId { get; set; }

    public User User { get; set; }

    public Guid EntityId { get; set; }

    public T Entity { get; set; }

    public EntityUserAccess(Guid id ,string userId, User user, Guid entityId, T entity)
    {
        Id = id;
        UserId = userId;
        User = user;
        EntityId = entityId;
        Entity = entity;
    }

    public EntityUserAccess()
    {
    }
}