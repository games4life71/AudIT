using FileInfo = Radzen.FileInfo;

namespace Frontend.EntityDtos.Document.Standalone;

public class MultipleCreateStandaloneDocument
{
    public List<FileInfo> UploadDocuments { get; set; }

    public string? Name { get; set; }

    public string? Extension { get; set; }

    public Guid OwnerId { get; set; }

    public Guid DepartmentId { get; set; }
}