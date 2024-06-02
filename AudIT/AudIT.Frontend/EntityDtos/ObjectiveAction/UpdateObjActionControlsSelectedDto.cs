namespace Frontend.EntityDtos.ObjectiveAction;

public class UpdateObjActionControlsSelectedDto
{
    public Guid Id { get; set; }

    public bool Selected { get; set; }

    public List<String> ControaleInterneExistente { get; set; } = [];

    public List<String> ControaleInterneAsteptate { get; set; } = [];

    public UpdateObjActionControlsSelectedDto()
    {

    }
}