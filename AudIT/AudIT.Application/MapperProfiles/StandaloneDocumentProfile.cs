using AudIT.Applicationa.Requests.Document.StandaloneDocument.DTO;
using AudiT.Domain.Entities;
using AutoMapper;

namespace AudIT.Applicationa.MapperProfiles;

public class StandaloneDocumentProfile:MyCustomProfile
{

    public StandaloneDocumentProfile()
    {
        CreateMap<StandaloneDocument, BaseStandaloneDto>();

    }


}