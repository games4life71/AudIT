using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Requests.AuditMission.Commands.Create;

public class
    CreateBaseAudMissionHandler(
        IAuditMissionRepository _auditRepo,
        UserManager<AudiT.Domain.Entities.User> _userManager,
        IDepartmentRepository _departmentRepo,
        IMapper _mapper
    )
    : IRequestHandler<CreateBaseAuditMIssionCommand, BaseDTOResponse<BaseAuditMissionDto>>
{
    public async Task<BaseDTOResponse<BaseAuditMissionDto>> Handle(CreateBaseAuditMIssionCommand request,
        CancellationToken cancellationToken)
    {
        //get the users and the department

        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("User not found", false);
        }

        var department = await _departmentRepo.FindByIdAsync(request.DepartmentId);

        if (department == null)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("Department not found", false);
        }

        // Create a new AuditMission object

        var new_mission = AudiT.Domain.Entities.AuditMission.Create(
            request.Name,
            user,
            Guid.Parse(request.UserId),
            department.Value,
            request.DepartmentId
        );


        if (!new_mission.IsSuccess)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("Failed to create new mission", false);
        }

        // Save the new mission to the database
        var result = await _auditRepo.AddAsync(new_mission.Value);
        if (!result.IsSuccess)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("Failed to create new mission", false);
        }

        // Return the new mission
        return new BaseDTOResponse<BaseAuditMissionDto>(_mapper.Map<BaseAuditMissionDto>(result.Value), "Success",
            true);
    }
}