using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Command.Delete;

public class DeleteDepartmentCommand : IRequest<BaseResponse>
{
    public Guid Id { get; set; }

    public DeleteDepartmentCommand(Guid id)
    {
        Id = id;
    }
}