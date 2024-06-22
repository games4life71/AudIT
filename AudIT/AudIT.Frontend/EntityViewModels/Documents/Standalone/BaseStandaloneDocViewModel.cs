namespace Frontend.EntityViewModels.Documents.Standalone;

public class BaseStandaloneDocViewModel
{
    public Guid id { get; set; }

    public string name { get; set; }

    public string extension { get; set; }

    public Guid ownerId { get; set; }

    public Guid departmentId { get; set; }

    public BaseStandaloneDocViewModel(Guid id, string name, string extension, Guid ownerId, Guid departmentId)
    {
        this.id = id;
        this.name = name;
        this.extension = extension;
        this.ownerId = ownerId;
        this.departmentId = departmentId;
    }

    public BaseStandaloneDocViewModel()
    {
    }
}