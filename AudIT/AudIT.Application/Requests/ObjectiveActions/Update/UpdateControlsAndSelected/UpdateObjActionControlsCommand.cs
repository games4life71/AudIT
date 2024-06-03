using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Update.UpdateControlsAndSelected;

public class UpdateObjActionControlsCommand : IRequest<BaseDTOResponse<BaseObjActionDto>>
{
    public Guid Id { get; set; }

    public bool Selected { get; set; }

    public List<String> ControaleInterneExistente { get; set; } = [];

    public List<String> ControaleInterneAsteptate { get; set; } = [];
}