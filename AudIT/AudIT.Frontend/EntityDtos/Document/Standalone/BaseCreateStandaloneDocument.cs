using FileInfo = Radzen.FileInfo;

namespace Frontend.EntityDtos.Document.Standalone;

public class BaseCreateStandaloneDocument
{

    public FileInfo UploadDocument { get; set; }

    public string? Name { get; set; }

    public string? Extension { get; set; }

    public Guid OwnerId { get; set; }

    public Guid DepartmentId { get; set; }

}