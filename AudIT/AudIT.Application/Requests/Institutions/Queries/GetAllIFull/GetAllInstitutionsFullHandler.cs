using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetAllIFull;

public class GetAllInstitutionsFullHandler(
    IInstitutionRepository institutionRepository,
    IMapper mapper
) : IRequestHandler<GetAllInstitutionsFullQuery, BaseDTOResponse<InstitutionInfoDto>>
{
    public async Task<BaseDTOResponse<InstitutionInfoDto>> Handle(GetAllInstitutionsFullQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var institutions = await institutionRepository.GetAllInstitutionsFullAsync();

            if (!institutions.IsSuccess)
            {
                return new BaseDTOResponse<InstitutionInfoDto>("No institutions found.", false);
            }

            var institutionsDto = mapper.Map<List<InstitutionInfoDto>>(institutions.Value);

            return new BaseDTOResponse<InstitutionInfoDto>(institutionsDto, "Institutions found.", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<InstitutionInfoDto>(e.Message, false);
        }
    }
}