using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetAll;

public class GetAllInstitutionsHandler(
    IInstitutionRepository institutionRepository,
    IMapper mapper
) : IRequestHandler<GetAllInstitutionsCommand, BaseDTOResponse<BaseInstitutionDto>>
{
    public async Task<BaseDTOResponse<BaseInstitutionDto>> Handle(GetAllInstitutionsCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await institutionRepository.GetAllAsync();

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseInstitutionDto>("Error while fetching data for institutions", false);
            }

            var institutions = mapper.Map<List<BaseInstitutionDto>>(result.Value);


            return new BaseDTOResponse<BaseInstitutionDto>(institutions, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseInstitutionDto>("Error while fetching data for institutions", false);
        }
    }
}