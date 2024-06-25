using AudIT.Applicationa.Requests.EntityAcces.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;


namespace AudIT.Applicationa.Requests.EntityAcces.Commands.Create;

public class CreateEntityAccesCommand : IRequest<BaseDTOResponse<BaseEntityAccesDto>>
{
    public string UserId { get; set; }

    public string GrantedByUserId { get; set; }

    public Guid EntityId { get; set; }

    public EntityType Type { get; set; }

    public AccesType AccesType { get; set; }
}