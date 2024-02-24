using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Commands.Delete;

public class DeleteHandler(IDepartmentRepository _repository) : IRequestHandler<DeleteCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.DeleteAsync(request.Id);
            //if it is successful
            if (result.IsSuccess)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Deleted Successfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Failed to delete"
                };
            }
        }

        catch (Exception e)
        {
            return new BaseResponse
            {
                Success = false,
                Message = e.Message
            };
        }
    }
}