using Frontend.EntityViewModels.EntityAccess;

namespace Frontend.EntityDtos.EntityAcces;

public class BaseCreateEntityaAccesDto
{
    public string UserId { get; set; }

    public string? GrantedByUserId { get; set; } = "";

    public Guid EntityId { get; set; }

    public EntityType Type { get; set; }

    public AccesType AccesType { get; set; }
}