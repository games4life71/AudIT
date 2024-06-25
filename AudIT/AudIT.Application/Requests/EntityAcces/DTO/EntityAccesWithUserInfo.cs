using AudIT.Applicationa.Requests.User.Dto;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.EntityAcces.DTO;

public class EntityAccesWithUserInfo
{
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public BaseUserInformationDto User { get; set; }

    public string GrantedByUserId { get; set; }

    public Guid EntityId { get; set; }

    public EntityType Type { get; set; }

    public AccesType AccesType { get; set; }
}