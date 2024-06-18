using Frontend.EntityViewModels.ObjectiveAction;
using Frontend.EntityViewModels.Recommendation;

namespace Frontend.EntityDtos.Recommendation;

public class UpdateRecommendationDto
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public Status Status { get; set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string RecommendationDescription { get; set; }

    public UpdateRecommendationDto(Guid id, string description, DateTime dueDate, Status status, string problem,
        string? aditionalFindings, string? cause, string? consequence, string recommendationDescription)
    {
        Id = id;
        Description = description;
        DueDate = dueDate;
        Status = status;
        Problem = problem;
        AditionalFindings = aditionalFindings;
        Cause = cause;
        Consequence = consequence;
        RecommendationDescription = recommendationDescription;
    }

    public UpdateRecommendationDto()
    {
    }
}