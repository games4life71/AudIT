using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Commands.Create;

public class CreateRecommendationCommand : IRequest<BaseDTOResponse<BaseRecommendationDTO>>
{
    public string Description { get; set; }

    public Status Status { get; set; }

    public DateTime DueDate { get; set; }

    public Guid ObjectiveActionId { get; set; }

    public CreateRecommendationCommand(string description, Status status, DateTime dueDate, Guid objectiveActionId)
    {
        Description = description;
        Status = status;
        DueDate = dueDate;
        ObjectiveActionId = objectiveActionId;
    }
}