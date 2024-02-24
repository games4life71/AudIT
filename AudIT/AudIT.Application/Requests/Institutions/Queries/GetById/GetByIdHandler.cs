using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetById;

public class GetByIdHandler(IInstitutionRepository _repository, IMapper _mapper)
    : IRequestHandler<GetByIdQuery, BaseDTOResponse<BaseInstitutionDto>>
{
    public async Task<BaseDTOResponse<BaseInstitutionDto>> Handle(GetByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var institution = await _repository.FindByIdAsync(request.Id);

            if (!institution.IsSuccess)
            {
                return new BaseDTOResponse<BaseInstitutionDto>($"Institution with id {request.Id} not  found.", false);
            }

            return new BaseDTOResponse<BaseInstitutionDto>(_mapper.Map<BaseInstitutionDto>(institution), "Succes",
                true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseInstitutionDto>(
                $"An error occurred when getting institution with id {request.Id}: {e.Message}", false);
        }
    }
}