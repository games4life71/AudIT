using AudIT.Applicationa.Requests.Export.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Export.Activity.CSV;

public class ExportActivityCSVCommand : IRequest<BaseDTOResponse<BaseExportDto>>
{
    public List<Guid> ActivityIds { get; set; }
}