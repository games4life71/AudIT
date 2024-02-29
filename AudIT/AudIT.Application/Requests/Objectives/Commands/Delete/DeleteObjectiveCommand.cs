using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Commands.Delete;

public class DeleteObjectiveCommand(Guid id) : IRequest<BaseResponse>
{
    public Guid Id { get; set; } = id;
}