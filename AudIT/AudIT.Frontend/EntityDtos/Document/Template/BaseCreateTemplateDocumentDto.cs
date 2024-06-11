using FileInfo = Radzen.FileInfo;

namespace Frontend.EntityDtos.Document.Template;

public class BaseCreateTemplateDocumentDto
{
    public List<FileInfo> Files { get; set; } = [];

    public string Name { get; set; }

    public string Extension { get; set; }

    public string OwnerId { get; set; }

    public DocumentState State { get; set; }

    public TemplateTypeStage Type { get; set; }

    public string Version { get; set; }
}

public enum TemplateTypeStage
{
    //TODO : Add more types as the need arises
    PregatireaMisiunii,
    InterventieLaFataLocului,
    RaportareRezultate,
    UrmarireaRecomandari
}

public enum DocumentState
{
    Draft,
    Published,
    Archived
}