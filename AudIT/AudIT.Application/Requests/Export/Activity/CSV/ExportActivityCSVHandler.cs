using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Requests.Export.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Export.Activity.CSV;

public class ExportActivityCSVHandler(
    IActivityRepository activityRepository,
    IExporterService exporterService,
    IMapper mapper) : IRequestHandler<ExportActivityCSVCommand, BaseDTOResponse<BaseExportDto>>
{
    public async Task<BaseDTOResponse<BaseExportDto>> Handle(ExportActivityCSVCommand request,
        CancellationToken cancellationToken)
    {
        List<AudiT.Domain.Entities.Activity> activities = [];

        foreach (var activityId in request.ActivityIds)
        {
            var activity = await activityRepository.FindByIdAsync(activityId);

            if (!activity.IsSuccess)
            {
                return new BaseDTOResponse<BaseExportDto>($"Activity with id {activityId} not found", false);
            }


            activities.Add(activity.Value);
        }

        //TODO  change the name of the file maybe ?
        var exportedActivities = await exporterService.ExportAsync(activities, "Activities.csv");

        if (!exportedActivities.Item1)
        {
            return new BaseDTOResponse<BaseExportDto>(exportedActivities.Item3, false);
        }

        var exportDTO = new BaseExportDto(ids: request.ActivityIds, exportType: "Activity",
            exportFormat: ExportType.Csv, exportedData: exportedActivities.Item2);

        return new BaseDTOResponse<BaseExportDto>(exportDTO, " Succesfully exported data", true);
    }
}