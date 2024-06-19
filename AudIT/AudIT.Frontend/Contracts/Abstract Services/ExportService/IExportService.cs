namespace Frontend.Contracts.Abstract_Services.ExportService;

public interface IExportService
{
    public const string ApiPath = "https://localhost:7248/api/Export";

    public Task<Stream?> ExportActivitiesCSVAsync(List<Guid> activityIds);

    public Task<Stream> ExportFiapAsync(Guid fiapId);

    public Task<Stream?> ExportObjectivesFullAsync(Guid AuditMissionId);
}