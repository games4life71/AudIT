using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.Recommendations.DTO;

public class BaseRecommendationDTO
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public Status Status { get; set; }

    public BaseObjActionDto ObjectiveAction { get; private set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string RecommendationDescription { get; set; }

    public BaseRecommendationDTO(Guid id, string description, DateTime dueDate, Status status, BaseObjActionDto objectiveAction, string problem, string? aditionalFindings, string? cause, string? consequence, string recommendationDescription)
    {
        Id = id;
        Description = description;
        DueDate = dueDate;
        Status = status;
        ObjectiveAction = objectiveAction;
        Problem = problem;
        AditionalFindings = aditionalFindings;
        Cause = cause;
        Consequence = consequence;
        RecommendationDescription = recommendationDescription;
    }
}