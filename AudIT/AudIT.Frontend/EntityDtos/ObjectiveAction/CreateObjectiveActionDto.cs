namespace Frontend.EntityDtos.ObjectiveAction;

public class CreateObjectiveActionDto
{
    public string Name { get; set; }

    public Guid ObjectiveId { get; set; }


    public CreateObjectiveActionDto()
    {
        // Name = string.Empty;
        Name = "";
            ObjectiveId = Guid.Empty;
    }
}