using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Document;

namespace Frontend.Contracts.Abstract_Services.DocumentService;

public interface IDocumentService
{
    public const String ApiPathBaseDocument = "https://localhost:7248/api/v1/BaseDocument";

    public Task<BaseDTOResponse<BaseDocumentViewmodel>> GetRecentDocumentsAsync(Guid userId);
}