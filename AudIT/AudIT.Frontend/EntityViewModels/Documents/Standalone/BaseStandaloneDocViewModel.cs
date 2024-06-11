namespace Frontend.EntityViewModels.Documents.Standalone;

public class BaseStandaloneDocViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Extension { get; set; }

    public Guid OwnerId { get; set; }

    public Guid DepartmentId { get; set; }
}