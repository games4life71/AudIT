using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Delete;

public class DeleteHandler(IStandaloneDocRepository standaloneDocRepository)
{
    public async Task<BaseResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await standaloneDocRepository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new BaseResponse()
                {
                    Message = "Failed to delete document",
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