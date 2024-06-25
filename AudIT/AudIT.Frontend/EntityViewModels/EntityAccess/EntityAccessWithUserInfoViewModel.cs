using Frontend.EntityViewModels.User;

namespace Frontend.EntityViewModels.EntityAccess;

public class EntityAccessWithUserInfoViewModel
{
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public BaseUserViewModel User { get; set; }

    public string GrantedByUserId { get; set; }

    public Guid EntityId { get; set; }

    public EntityType Type { get; set; }

    public AccesType AccesType { get; set; }
}