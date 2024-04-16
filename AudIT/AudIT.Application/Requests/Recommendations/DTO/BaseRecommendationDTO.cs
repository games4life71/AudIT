using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.Recommendations.DTO;

public class BaseRecommendationDTO
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public Status Status { get; set; }

    public ObjectiveAction ObjectiveAction { get; private set; }

    public BaseRecommendationDTO(Guid id, string description, DateTime dueDate, ObjectiveAction objectiveAction,
        Status status)
    {
        Id = id;
        Description = description;
        DueDate = dueDate;
        ObjectiveAction = objectiveAction;
        Status = status;
    }
}