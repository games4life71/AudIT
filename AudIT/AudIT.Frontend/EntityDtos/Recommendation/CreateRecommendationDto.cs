using Frontend.EntityViewModels.Recommendation;

namespace Frontend.EntityDtos.Recommendation;

public class CreateRecommendationDto
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
}