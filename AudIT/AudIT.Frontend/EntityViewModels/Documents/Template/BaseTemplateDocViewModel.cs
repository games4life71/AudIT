using Frontend.EntityDtos.Document.Template;

namespace Frontend.EntityViewModels.Documents.Template;

public class BaseTemplateDocViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Extension { get; set; }

    public Guid OwnerId { get; set; }

    public TemplateTypeStage Type { get; set; }

    public DocumentState State { get; set; }

    public string Version { get; set; }
}