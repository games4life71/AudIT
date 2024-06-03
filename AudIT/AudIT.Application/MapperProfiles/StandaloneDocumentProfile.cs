using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Requests.Document.StandaloneDocument.DTO;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using AutoMapper;

namespace AudIT.Applicationa.MapperProfiles;

public class StandaloneDocumentProfile:MyCustomProfile
{

    public StandaloneDocumentProfile()
    {
        CreateMap<StandaloneDocument, BaseStandaloneDto>();
        CreateMap<StandaloneDocument, DocumentWithDepartmentDto>();
        CreateMap<BaseDocument, BaseDocumentDto>();

    }


}