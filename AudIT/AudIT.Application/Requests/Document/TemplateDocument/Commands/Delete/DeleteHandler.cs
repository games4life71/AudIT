using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.TemplateDocument.Commands.Delete;

public class DeleteHandler(ITemplateDocRepository _docRepo) : IRequestHandler<DeleteCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _docRepo.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new BaseResponse()
                {
                    Message = result.Error,
                    Success = false
                };
            }

            return new BaseResponse()
            {
                Message = "Document deleted successfully",
                Success = true
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BaseResponse()
            {
                Message = e.Message,
                Success = false
            };
        }
    }
}