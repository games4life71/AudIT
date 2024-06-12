﻿using Frontend.EntityDtos.Department;
using Frontend.EntityDtos.Document.Standalone;
using Frontend.EntityDtos.Document.Template;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Document;
using Frontend.EntityViewModels.Documents;
using Frontend.EntityViewModels.Documents.Standalone;
using Frontend.EntityViewModels.Documents.Template;

namespace Frontend.Contracts.Abstract_Services.DocumentService;

public interface IDocumentService
{
    public const String ApiPathBaseDocument = "https://localhost:7248/api/v1/BaseDocument";
    public const String ApiStandalonePath = "https://localhost:7248/api/v1/StandaloneDocument";
    public const String ApiTemplatePath = "https://localhost:7248/api/v1/TemplateDocument";


    public Task<BaseDTOResponse<BaseDocumentViewmodel>> GetRecentDocumentsAsync();

    public Task<BaseDTOResponse<BaseTemplateDocViewModel>> UploadTemplateDocumentAsync(
        BaseCreateTemplateDocumentDto documentDto);

    public Task<BaseDTOResponse<BaseStandaloneDocViewModel>> UploadStandaloneDocumentAsync(
        BaseCreateStandaloneDocument documentDto);


    public Task<BaseDTOResponse<BaseStandaloneDocViewModel>> UploadMultipleStandaloneDocsAsync(
        MultipleCreateStandaloneDocument documentDto);

    public Task<Stream?> DownloadTemplateDocumentAsync(string documentName);


    public Task<BaseDTOResponse<BaseDocumentViewModel>> GetDocumentsByUserIdAsync();

    public Task<BaseResponse> DeleteDocumentAsync(Guid documentId);


}