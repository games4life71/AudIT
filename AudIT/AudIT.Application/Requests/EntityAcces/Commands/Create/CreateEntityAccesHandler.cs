using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.EntityAcces.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.EntityAcces.Commands.Create;

public class CreateEntityAccesHandler(
    IEntityAccesRepository entityAccesRepository,
    IMapper mapper
) : IRequestHandler<CreateEntityAccesCommand, BaseDTOResponse<BaseEntityAccesDto>>
{
    public async Task<BaseDTOResponse<BaseEntityAccesDto>> Handle(CreateEntityAccesCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var existingEntity = await entityAccesRepository.FindByEntityIdAsync(request.EntityId, request.Type, request.UserId);

            if (existingEntity.IsSuccess)
            {
                Console.WriteLine("Entity acces already exists");
                return new BaseDTOResponse<BaseEntityAccesDto>
                {
                    Success = false,
                    Message = $"Entity acces already exists for {request.Type} with id {request.EntityId}"
                };
            }


            var newEntityAcess = AudiT.Domain.Entities.EntityAcces.Create(
                request.UserId,
                request.EntityId,
                request.Type,
                request.AccesType,
                request.GrantedByUserId
            );

            var addResult = await entityAccesRepository.AddAsync(newEntityAcess.Value);

            if (!addResult.IsSuccess)
            {
                return new BaseDTOResponse<BaseEntityAccesDto>
                {
                    Success = false,
                    Message = addResult.Error
                };
            }

            var dto = mapper.Map<BaseEntityAccesDto>(addResult.Value);

            return new BaseDTOResponse<BaseEntityAccesDto>(dto, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseEntityAccesDto>
            {
                Success = false,
                Message = e.Message
            };
        }
    }
}