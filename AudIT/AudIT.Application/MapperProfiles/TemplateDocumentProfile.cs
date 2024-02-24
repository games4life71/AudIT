using AudIT.Applicationa.Requests.Document.TemplateDocument.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class TemplateDocumentProfile : MyCustomProfile
{
    public TemplateDocumentProfile()
    {
        CreateMap<TemplateDocument, BaseTemplateDocDto>();
    }
}