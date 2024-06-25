using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.EntityAcces.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.EntityAcces.Queries.GetAllGrantedByUser;

public class GetAllGrantedAccesByUserIdHandler(
    IEntityAccesRepository entityAccesRepository,
    IMapper mapper
) : IRequestHandler<GetAllGrantedAccesByUserIdQuery, BaseDTOResponse<EntityAccesWithUserInfo>>
{
    public async Task<BaseDTOResponse<EntityAccesWithUserInfo>> Handle(GetAllGrantedAccesByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var accessResponse = await entityAccesRepository.GetAllGrantedAccesByUserId(request.UserId);

            if (!accessResponse.IsSuccess)
            {
                return new BaseDTOResponse<EntityAccesWithUserInfo>("Error while fetching data", false);
            }

            var mappedData = mapper.Map<List<EntityAccesWithUserInfo>>(accessResponse.Value);

            return new BaseDTOResponse<EntityAccesWithUserInfo>(mappedData, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<EntityAccesWithUserInfo>("Error while fetching data", false);
        }
    }
}