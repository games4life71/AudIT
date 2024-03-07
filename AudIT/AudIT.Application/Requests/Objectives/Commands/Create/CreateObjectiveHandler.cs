using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objective.Commands.Create;
using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Commands.Create;

public class CreateObjectiveHandler(
    IObjectiveRepository objectiveRepository,
    IAuditMissionRepository _auditMissionRepository,
    IMapper mapper) : IRequestHandler<CreateObjectiveCommand, BaseDTOResponse<BaseObjectiveDto>>
{
    public async Task<BaseDTOResponse<BaseObjectiveDto>> Handle(CreateObjectiveCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var auditMiss = await _auditMissionRepository.FindByIdAsync(request.AuditMissionId);

            if (!auditMiss.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>("No audit mission found", false);
            }


            var newObj = AudiT.Domain.Entities.Objective.Create(
                name: request.Name,
                auditMissionId: auditMiss.Value.Id
            );


            if (!newObj.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>("Cannot create new Objective", false);
            }

            Console.WriteLine(newObj.Value.Id);
            Console.WriteLine(newObj.Value.AuditMissionId);
            Console.WriteLine(newObj.Value.Name);
            await objectiveRepository.AddAsync(newObj.Value);

            return new BaseDTOResponse<BaseObjectiveDto>(mapper.Map<BaseObjectiveDto>(newObj.Value), "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjectiveDto>("An error occured " + e.Message+e.InnerException, false);
        }
    }
}