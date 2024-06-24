using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.EntityAcces.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.EntityAcces.Queries.GetAllByUser;

public class GetAllAccesByUserHandler(
    IEntityAccesRepository entityAccesRepository,
    IMapper mapper

    ): IRequestHandler<GetAllAccesByUserIdQuery, BaseDTOResponse<BaseEntityAccesDto>>
{
    public async Task<BaseDTOResponse<BaseEntityAccesDto>> Handle(GetAllAccesByUserIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entityAcces = await entityAccesRepository.GetAllByUserId(request.UserId);

            if (!entityAcces.IsSuccess)
            {
                return new BaseDTOResponse<BaseEntityAccesDto>("Failed to get entity acces", false);
            }

            var entityAccesDto = mapper.Map<List<BaseEntityAccesDto>>(entityAcces.Value);

            return new BaseDTOResponse<BaseEntityAccesDto>(entityAccesDto, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseEntityAccesDto>(e.Message, false);
        }
    }
}