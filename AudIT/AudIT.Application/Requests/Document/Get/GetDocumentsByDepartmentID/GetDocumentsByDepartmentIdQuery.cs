using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Get.GetDocumentsByDepartmentID;

public class GetDocumentsByDepartmentIdQuery:IRequest<BaseDTOResponse<DocumentWithDepartmentDto>>
{
    public Guid DepartmentId { get; set; }

    public GetDocumentsByDepartmentIdQuery(Guid departmentId)
    {
        DepartmentId = departmentId;
    }



}