using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.ExportService;

namespace Frontend.Services.ExportService;

public class ExportService(HttpClient httpClient) : IExportService
{
    public async Task<Stream?> ExportActivitiesCSVAsync(List<Guid> activityIds)
    {
        var response = await httpClient.PostAsJsonAsync($"{IExportService.ApiPath}/activities/csv", activityIds);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStreamAsync();
        }

        return null;
    }

    public async Task<Stream>? ExportFiapAsync(Guid fiapId)
    {
        var result = await httpClient.GetAsync($"{IExportService.ApiPath}/fiap/{fiapId}");

        if (result.IsSuccessStatusCode)
        {
            return await result.Content.ReadAsStreamAsync();
        }

        return null;
    }

    public async Task<Stream?> ExportObjectivesFullAsync(Guid AuditMissionId)
    {
        var result = await httpClient.GetAsync($"{IExportService.ApiPath}/objectives-and-actions/xls/{AuditMissionId}");

        if (result.IsSuccessStatusCode)
        {
            return await result.Content.ReadAsStreamAsync();
        }

        return null;
    }
}