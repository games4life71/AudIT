using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Models.Export.Activity;
using AudIT.Applicationa.Requests.Export.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Export.Activity.CSV;

public class ExportActivityCSVHandler(
    IActivityRepository activityRepository,
    IExporterService<ActivityExportModel> exporterService,
    IMapper mapper) : IRequestHandler<ExportActivityCSVCommand, BaseDTOResponse<BaseExportDto>>
{
    public async Task<BaseDTOResponse<BaseExportDto>> Handle(ExportActivityCSVCommand request,
        CancellationToken cancellationToken)
    {
        List<ActivityExportModel> activities = [];

        foreach (var activityId in request.ActivityIds)
        {
            var activity = await activityRepository.FindByIdForExportAsync(activityId);

            if (!activity.IsSuccess)
            {
                return new BaseDTOResponse<BaseExportDto>($"Activity with id {activityId} not found", false);
            }


            activities.Add(activity.Value);
        }

        var fileName = $"Activities_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv";


        var exportedActivities = await exporterService.ExportMultipleAsync(activities, fileName);

        if (!exportedActivities.Item1)
        {
            return new BaseDTOResponse<BaseExportDto>(exportedActivities.Item3, false);
        }

        var exportDTO = new BaseExportDto(ids: request.ActivityIds, exportType: "Activity",
            exportFormat: ExportType.Csv, exportedData: exportedActivities.Item2);

        return new BaseDTOResponse<BaseExportDto>(exportDTO, " Succesfully exported data", true);
    }
}