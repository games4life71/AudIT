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
}

public enum Status
{
    Implemented,
    PartiallyImplemented,
    NotImplemented,
}