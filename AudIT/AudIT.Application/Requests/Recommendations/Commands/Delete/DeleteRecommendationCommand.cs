using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Commands.Delete;

public class DeleteRecommendationCommand : IRequest<BaseResponse>
{
    public Guid Id { get; set; }

    public DeleteRecommendationCommand(Guid id)
    {
        Id = id;
    }
}