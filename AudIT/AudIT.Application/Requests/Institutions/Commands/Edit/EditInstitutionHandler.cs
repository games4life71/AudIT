using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Commands.Edit;

public class EditInstitutionHandler(
    IInstitutionRepository _institutionRepository,
    IMapper _mapper
) : IRequestHandler<EditInstitutionCommand, BaseDTOResponse<InstitutionInfoDto>>
{
    public async Task<BaseDTOResponse<InstitutionInfoDto>> Handle(EditInstitutionCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var institution = await _institutionRepository.FindByIdAsync(request.Id);

            if (!institution.IsSuccess)
                return new BaseDTOResponse<InstitutionInfoDto>("Institution not found", false);


            institution.Value.Update(
                request.Name,
                request.Address,
                request.PhoneNumber
            );

            var result = await _institutionRepository.UpdateAsync(institution.Value);

            if (!result.IsSuccess)
                return new BaseDTOResponse<InstitutionInfoDto>("Failed to update institution", false);

            return new BaseDTOResponse<InstitutionInfoDto>(_mapper.Map<InstitutionInfoDto>(result.Value));
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<InstitutionInfoDto>(e.Message, false);
        }
    }
}