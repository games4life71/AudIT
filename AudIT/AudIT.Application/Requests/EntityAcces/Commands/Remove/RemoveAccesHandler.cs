using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.EntityAcces.Commands.Remove;

public class RemoveAccesHandler(
    IEntityAccesRepository entityAccesRepository
) : IRequestHandler<RemoveAccesCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(RemoveAccesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entityAcces = await entityAccesRepository.FindByIdAsync(request.Id);

            if (!entityAcces.IsSuccess)
            {
                return new BaseResponse("EntityAcces not found.", false);
            }

            var result = await entityAccesRepository.RemoveAsync(entityAcces.Value);


            if (!result.IsSuccess)
            {
                return new BaseResponse("Cannot remove EntityAcces.", false);
            }

            return new BaseResponse("EntityAcces removed successfully.", true);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}