using AudIT.Applicationa.Requests.Export.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Export.Fiap;

public class ExportFiapCommand : IRequest<BaseDTOResponse<BaseExportDto>>
{
    public Guid Id { get; set; }
}