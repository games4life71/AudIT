using Frontend.EntityViewModels.ObjectiveAction;

namespace Frontend.EntityViewModels.Recommendation;

public class BaseRecommendationViewModel
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public Status Status { get; set; }

    public BaseObjectiveActionViewModel ObjectiveAction { get;  set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string RecommendationDescription { get; set; }

    public BaseRecommendationViewModel(Guid id, string description, DateTime dueDate, Status status, BaseObjectiveActionViewModel objectiveAction, string problem, string? aditionalFindings, string? cause, string? consequence, string recommendationDescription)
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

    public BaseRecommendationViewModel()
    {

    }
}

public enum Status
{
    Implemented,
    PartiallyImplemented,
    NotImplemented,
}