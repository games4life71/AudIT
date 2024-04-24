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

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string RecommendationDescription { get; set; }



    public CreateRecommendationCommand(string description, Status status, DateTime dueDate, Guid objectiveActionId, string problem, string? aditionalFindings, string? cause, string? consequence, string recommendationDescription)
    {
        Description = description;
        Status = status;
        DueDate = dueDate;
        ObjectiveActionId = objectiveActionId;
        Problem = problem;
        AditionalFindings = aditionalFindings;
        Cause = cause;
        Consequence = consequence;
        RecommendationDescription = recommendationDescription;
    }
}