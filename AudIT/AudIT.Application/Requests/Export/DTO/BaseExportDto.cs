namespace AudIT.Applicationa.Requests.Export.DTO;

public class BaseExportDto
{
    public List<Guid> Ids { get; set; }

    public string ExportType { get; set; }

    public ExportType ExportFormat { get; set; }

    public Stream ExportedData { get; set; }

    public BaseExportDto(List<Guid> ids,Stream exportedData, string exportType, ExportType exportFormat)
    {
        ExportedData = exportedData;
        Ids = ids;
        ExportType = exportType;
        ExportFormat = exportFormat;
    }
}

public enum ExportType
{
    Csv,
    Pdf,
    Excel,
    Word,
    Json,
    Xml
}