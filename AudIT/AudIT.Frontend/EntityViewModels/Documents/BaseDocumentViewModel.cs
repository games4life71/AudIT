namespace Frontend.EntityViewModels.Documents;

public class BaseDocumentViewModel
{
    public Guid Id { get;  set; }

    public string Name { get;  set; }

    public string Extension { get;  set; }

    public string OwnerId { get;  set; }

    public DocumentType DocumentType { get;  set; }
}

public enum DocumentType
{
    Standalone,
    Template
}