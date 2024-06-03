using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Models.Export.Fiap;
using AudIT.Applicationa.Requests.Export.DTO;
using AudIT.Applicationa.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AudIT.Applicationa.Requests.Export.Fiap;

public class ExportFiapHandler(
    IObjectiveActionFiapRepository fiapRepository,
    IInstitutionRepository institutionRepository,
    IExporterService<FiapDocModel> exporterService,
    IHttpContextAccessor httpContextAccessor
) : IRequestHandler<ExportFiapCommand, BaseDTOResponse<BaseExportDto>>
{

    public async Task<BaseDTOResponse<BaseExportDto>> Handle(ExportFiapCommand request,
        CancellationToken cancellationToken)
    {
        // Get the data from the repository
        var resultFiap = await fiapRepository.FindByIdAsync(request.Id);
        var resultInstitution = await institutionRepository.FindByIdAsync(Guid.Empty);
        if (!resultFiap.IsSuccess)
        {
            return new BaseDTOResponse<BaseExportDto>($"Cannot find Fiap with id {request.Id}", false);
        }


        //get the user name from the context
        var userName = httpContextAccessor.HttpContext.User.Identity.Name;



        //map it to the model
        var fiapResult = resultFiap.Value;
        var fiapModel = new FiapDocModel(
            title: fiapResult.Name,
            auditMissionName: fiapResult.AuditMission.Name,
            objectiveName: fiapResult.ObjectiveAction.Name,
            period: $"{fiapResult.AuditedPeriodStart.ToShortDateString()}-{fiapResult.AuditedPeriodEnd.ToShortDateString()}",
            userName: userName,
            problem: fiapResult.Problem,
            constatari: fiapResult.AditionalFindings,
            cauze: fiapResult.Cause,
            consecinte: fiapResult.Consequence,
            recomandari: fiapResult.Recommendation
        );

        var resultStream = await exporterService.ExportSingleAsync(fiapModel, $"fiap_export_{fiapResult.Name}.docx");


        var exportDto = new BaseExportDto(
            new List<Guid>(),
            resultStream.Item2,
            "Fiap",
            ExportType.Word
        );

        if (resultStream.Item1)
        {
            return new BaseDTOResponse<BaseExportDto>(exportDto, "suycces", true);
        }

        return new BaseDTOResponse<BaseExportDto>(resultStream.Item3, false);
    }
}