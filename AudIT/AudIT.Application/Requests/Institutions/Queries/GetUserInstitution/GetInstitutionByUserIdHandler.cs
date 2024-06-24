using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetUserInstitution;

public class GetInstitutionByUserIdHandler(
    IUserInstitutionRepository userInstitutionRepository,
    IMapper mapper
) : IRequestHandler<GetInstitutionByUserIdQuery, BaseDTOResponse<BaseInstitutionDto>>

{
    public async Task<BaseDTOResponse<BaseInstitutionDto>> Handle(GetInstitutionByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await userInstitutionRepository.GetInstitutionByUserId(request.UserId);

            if (!response.IsSuccess)
            {
                return new BaseDTOResponse<BaseInstitutionDto>("Error getting institution by user id", false);
            }

            var institutionDto = mapper.Map<BaseInstitutionDto>(response.Value);

            return new BaseDTOResponse<BaseInstitutionDto>(institutionDto, "Institution retrieved successfully", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseInstitutionDto>("Error getting institution by user id", false);
        }
    }
}