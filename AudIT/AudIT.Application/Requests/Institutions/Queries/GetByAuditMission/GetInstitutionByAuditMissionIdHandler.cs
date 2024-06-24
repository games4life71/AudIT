using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetByDepartment;

public class GetInstitutionByAuditMissionIdHandler(
    IInstitutionRepository institutionRepository,
    IMapper mapper
) : IRequestHandler<GetInstitutionByAuditMissionIdCommand, BaseDTOResponse<BaseInstitutionDto>>
{
    public async Task<BaseDTOResponse<BaseInstitutionDto>> Handle(GetInstitutionByAuditMissionIdCommand request,
        CancellationToken cancellationToken)
    {
        var institution = await institutionRepository.GetInstitutionByAuditMissionId(request.AuditMissionId);

        if (!institution.IsSuccess)
        {
            return new BaseDTOResponse<BaseInstitutionDto>("Institution not found", false);
        }

        return new BaseDTOResponse<BaseInstitutionDto>(mapper.Map<BaseInstitutionDto>(institution.Value), "Succces",
            true);
    }
}