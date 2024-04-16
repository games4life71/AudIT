using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Commands.Patch;

/// <summary>
/// This command is used to set/change the status of a recommendation
/// </summary>
public class SetRecommendationStatusCommand: IRequest<BaseDTOResponse<BaseRecommendationDTO>>
{
    public Guid Id { get; set; }

    public Status Status { get; set; }

    public SetRecommendationStatusCommand(Guid id, Status status)
    {
        Id = id;
        Status = status;
    }
}