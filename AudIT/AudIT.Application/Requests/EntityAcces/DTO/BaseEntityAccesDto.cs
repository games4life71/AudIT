using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.EntityAcces.DTO;

public class BaseEntityAccesDto
{
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public Guid EntityId { get; set; }

    public EntityType Type { get; set; }

    public AccesType AccesType { get; set; }
}