using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Models.Export.ObjectiveAndActions;
using AudIT.Applicationa.Requests.Export.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Export.ObjectiveAndActions.XLS;

public class ExportObjAndActionsXLSHandler(
    IObjectiveRepository objectiveRepository,
    IObjectiveActionRepository objectiveActionRepository,
    IAuditMissionRepository auditMissionRepository,
    IExporterService<ObjectiveAndActionsExportModel> exporterService,
    IMapper mapper
) : IRequestHandler<ExportObjectivesAndActionsXLSCommand, BaseDTOResponse<BaseExportDto>>
{
    public async Task<BaseDTOResponse<BaseExportDto>> Handle(ExportObjectivesAndActionsXLSCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var auditMission = await auditMissionRepository.FindByIdAsync(request.AuditMissionId);

            if (!auditMission.IsSuccess)
            {
                return new BaseDTOResponse<BaseExportDto>(
                    $"Could not find AuditMission with id {request.AuditMissionId}", false);
            }

            var objectives = await objectiveRepository.FindAllByAuditMissionIdAsync(request.AuditMissionId);

            if (!objectives.IsSuccess)
                return new BaseDTOResponse<BaseExportDto>($"Could not find Objectives for  {request.AuditMissionId}",
                    false);


            //retrieve the ObjectiveActions for the Objective and add them to the export model
            List<ObjectiveAndActionsExportModel> exportModels = [];

            foreach (var objective in objectives.Value)
            {
                var objectiveActions = await objectiveActionRepository.FindAllByObjectiveIdAsync(objective.Id);

                // if (objectiveActions.Value == null)
                // {
                //     return new BaseDTOResponse<BaseExportDto>(
                //         $"Something went wrong with retrieving Objective Action for Objective with id  {objective.Id}",
                //         false);
                // }

                exportModels.Add(new ObjectiveAndActionsExportModel(
                    objective.Name,
                    objectiveActions.Value,
                    auditMission.Value
                ));
            }


            var fileName = $"ObjectivesAndActions_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.xlsx";
            var exportedObjectives = await exporterService.ExportMultipleAsync(exportModels, fileName);

            if (!exportedObjectives.Item1)
            {
                return new BaseDTOResponse<BaseExportDto>(exportedObjectives.Item3, false);
            }

            var exportDTO = new BaseExportDto(ids: [request.AuditMissionId], exportType: "ObjectiveAndActions",
                exportFormat: ExportType.Excel, exportedData: exportedObjectives.Item2);

            return new BaseDTOResponse<BaseExportDto>(exportDTO, " Succesfully exported data", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseExportDto>($"An error occured while exporting data: {e.Message}", false);
        }
    }
}