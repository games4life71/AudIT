using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Frontend.Contracts.Abstract_Services.DocumentService;
using Frontend.EntityDtos.Document.Standalone;
using Frontend.EntityDtos.Document.Template;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Document;
using Frontend.EntityViewModels.Documents;
using Frontend.EntityViewModels.Documents.Standalone;
using Frontend.EntityViewModels.Documents.Template;
using Newtonsoft.Json;

namespace Frontend.Services.Document;

public class DocumentService(HttpClient httpClient) : IDocumentService
{
    public async Task<BaseDTOResponse<BaseDocumentViewmodel>> GetRecentDocumentsAsync()
    {
        var response =
            await httpClient.GetAsync(
                $"{IDocumentService.ApiPathBaseDocument}/get-recent-documents-by-user-id");

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

    public async Task<BaseDTOResponse<BaseTemplateDocViewModel>> UploadTemplateDocumentAsync(
        BaseCreateTemplateDocumentDto documentDto)
    {
        var content = new MultipartFormDataContent();

        foreach (var file in documentDto.Files)
        {
            var fileContent = new StreamContent(file.OpenReadStream());

            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"files\"",
                FileName = $"\"{file.Name}\""
            };

            content.Add(fileContent);
        }

        content.Add(new StringContent("Version"), documentDto.Version);
        content.Add(new StringContent(((int)documentDto.State).ToString()), "State");
        content.Add(new StringContent(((int)documentDto.Type).ToString()), "Type");

        var response = await httpClient.PostAsync($"{IDocumentService.ApiTemplatePath}/upload-template-documents",
            content);


        if (response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseTemplateDocViewModel>("Document uploaded successfully", true);
        }

        return new BaseDTOResponse<BaseTemplateDocViewModel>("Error while uploading template document");
    }

    public async Task<BaseDTOResponse<BaseStandaloneDocViewModel>> UploadStandaloneDocumentAsync(
        BaseCreateStandaloneDocument documentDto)
    {
        var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(documentDto.UploadDocument.OpenReadStream());

        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"UploadDocument\"",
            FileName = $"\"{documentDto.UploadDocument.Name}\""
        };

        content.Add(fileContent);

        //add the other form data

        // content.Add(new StringContent(documentDto.OwnerId.ToString()), "OwnerId");
        content.Add(new StringContent(documentDto.DepartmentId.ToString()), "DepartmentId");
        content.Add(new StringContent(String.Empty), "Name");
        content.Add(new StringContent(String.Empty), "Extension");


        var response = await httpClient.PostAsync($"{IDocumentService.ApiStandalonePath}/create-standalone-document",
            content);

        if (response.IsSuccessStatusCode)
        {
            //parse
            return new BaseDTOResponse<BaseStandaloneDocViewModel>("Document uploaded successfully", true);
        }

        return new BaseDTOResponse<BaseStandaloneDocViewModel>("Error while uploading standalone document");
    }

    public async Task<BaseDTOResponse<BaseStandaloneDocViewModel>> UploadMultipleStandaloneDocsAsync(
        MultipleCreateStandaloneDocument documentDto)
    {
        var content = new MultipartFormDataContent();
        foreach (var file in documentDto.UploadDocuments)
        {
            var fileContent = new StreamContent(file.OpenReadStream());

            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"uploadDocuments\"",
                FileName = $"\"{file.Name}\""
            };

            content.Add(fileContent);
        }


        content.Add(new StringContent(documentDto.DepartmentId.ToString()), "DepartmentId");
        content.Add(new StringContent(""), "Name");

        var response = await httpClient.PostAsync($"{IDocumentService.ApiStandalonePath}/upload-standalone-documents",
            content);

        if (response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseStandaloneDocViewModel>("Document uploaded successfully", true);
        }

        return new BaseDTOResponse<BaseStandaloneDocViewModel>("Error while uploading standalone document");
    }

    public async Task<Stream?> DownloadTemplateDocumentAsync(string documentName)
    {
        var response = await httpClient.GetAsync($"{IDocumentService.ApiTemplatePath}/{documentName}");

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            return stream;
        }

        return null;
    }

    public async Task<BaseDTOResponse<BaseDocumentViewModel>> GetDocumentsByUserIdAsync()
    {
        var response = await httpClient.GetAsync($"{IDocumentService.ApiPathBaseDocument}/get-documents-by-user-id");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseDocumentViewModel>>(responseContent);
            if (result != null) return result;
        }

        return new BaseDTOResponse<BaseDocumentViewModel>("Error while fetching documents");
    }

    public async Task<BaseResponse> DeleteDocumentAsync(Guid documentId)
    {
        var response = await httpClient.DeleteAsync($"{IDocumentService.ApiPathBaseDocument}/delete-document/{documentId}");

        if (response.IsSuccessStatusCode)
        {
            return new BaseResponse("Document deleted successfully", true);
        }

        return new BaseResponse("Error while deleting document", false);
    }
}