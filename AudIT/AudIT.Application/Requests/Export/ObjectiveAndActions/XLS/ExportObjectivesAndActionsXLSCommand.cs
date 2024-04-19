using AudIT.Applicationa.Requests.Export.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Export.ObjectiveAndActions.XLS;

/// <summary>
/// For a given AuditMission, export the Objectives and their corresponding ObjectiveActions to an XLS file
/// </summary>
public class ExportObjectivesAndActionsXLSCommand : IRequest<BaseDTOResponse<BaseExportDto>>
{
    public Guid AuditMissionId { get; set; }
}