using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Institution.Commands.Create;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Commands.Create;

public class CreateInstitutionHandler(IInstitutionRepository instRepository, IMapper mapper)
    : IRequestHandler<CreateInstitutionCommand, BaseDTOResponse<BaseInstitutionDto>>
{
    private readonly IInstitutionRepository _instRepository = instRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseDTOResponse<BaseInstitutionDto>> Handle(CreateInstitutionCommand request,
        CancellationToken cancellationToken)
    {
        //create a new institution entity

        var institution = AudiT.Domain.Entities.Institution.Create(
            name: request.Name,
            address: request.Name,
            homePhoneNumber: request.HomePhoneNumber
        );

        if (!institution.IsSuccess)
        {
            return new BaseDTOResponse<BaseInstitutionDto>();
        }

        //save the institution to the database

        var result = await _instRepository.AddAsync(institution.Value);

        var institutionDto = _mapper.Map<BaseInstitutionDto>(result.Value);

        return new BaseDTOResponse<BaseInstitutionDto>()
        {
            Success = true,
            Message = "Succes",
            DtoResponse = institutionDto
        };
    }
}