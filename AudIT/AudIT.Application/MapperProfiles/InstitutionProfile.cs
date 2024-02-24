using AudIT.Applicationa.Requests.Institution.Commands.Create;
using AudIT.Applicationa.Requests.Institution.DTO;
using AudiT.Domain.Entities;
using AutoMapper;

namespace AudIT.Applicationa.MapperProfiles;

public class InstitutionProfile : MyCustomProfile
{
    public InstitutionProfile()
    {
        CreateMap<Institution, BaseInstitutionDto>();
        CreateMap<CreateInstitutionCommand, Institution>();
        CreateMap<BaseInstitutionDto, Institution>();
    }
}