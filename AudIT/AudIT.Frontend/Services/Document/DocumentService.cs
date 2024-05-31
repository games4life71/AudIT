using System.Net;
using Frontend.Contracts.Abstract_Services.DocumentService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Document;
using Newtonsoft.Json;

namespace Frontend.Services.Document;

public class DocumentService(HttpClient httpClient) : IDocumentService
{
    public async Task<BaseDTOResponse<BaseDocumentViewmodel>> GetRecentDocumentsAsync(Guid userId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IDocumentService.ApiPathBaseDocument}/get-recent-documents-by-user-id/{userId}");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseDocumentViewmodel>>(responseContent);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<BaseDocumentViewmodel>("Error while fetching recent documents");
        }

        return new BaseDTOResponse<BaseDocumentViewmodel>("Error while fetching recent documents");
    }
}