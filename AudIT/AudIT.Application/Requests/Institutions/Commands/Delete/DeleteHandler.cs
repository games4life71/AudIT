using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Commands.Delete;

public class DeleteHandler(IInstitutionRepository _repository) : IRequestHandler<DeleteCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BaseResponse("Failed to delete institution", false);
        }

        return new BaseResponse("Institution deleted successfully", true);
    }
}