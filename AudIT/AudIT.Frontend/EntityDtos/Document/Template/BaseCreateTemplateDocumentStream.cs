namespace Frontend.EntityDtos.Document.Template;

public class BaseCreateTemplateDocumentStream
{
    public List<Stream?> UploadDocuments { get; set; } = [];

    public string Name { get; set; }

    public string? Extension { get; set; }

    public string? OwnerId { get; set; }

    public DocumentState State { get; set; }

    public TemplateTypeStage Type { get; set; }

    public string Version { get; set; }
}