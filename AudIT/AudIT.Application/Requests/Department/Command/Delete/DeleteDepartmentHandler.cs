using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Command.Delete;

public class DeleteDepartmentHandler(
    IDepartmentRepository _departmentRepository
) : IRequestHandler<DeleteDepartmentCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _departmentRepository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new BaseResponse("Failed to delete department", false);
            }

            return new BaseResponse("Department deleted successfully", true);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}