using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Requests.Activity.Commands.Add;

public class CreateActivityHandler(
    IActivityRepository _activityRepository,
    IDepartmentRepository _departmentRepository,
    UserManager<User> _userManager,
    IMapper mapper
)
    : IRequestHandler<CreateActivityCommand, BaseDTOResponse<BaseActivityDto>>
{
    public async Task<BaseDTOResponse<BaseActivityDto>> Handle(CreateActivityCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            //verify if the department exists
            var department = await _departmentRepository.FindByIdAsync(request.DepartmentId);

            if (!department.IsSuccess)
                return new BaseDTOResponse<BaseActivityDto>($"Department with id {request.DepartmentId} not found",
                    false);


            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return new BaseDTOResponse<BaseActivityDto>($"User with id {request.UserId} not found", false);

            var newActivity = AudiT.Domain.Entities.Activity.Create(
                request.Name,
                request.Type,
                department.Value,
                request.DepartmentId,
                user,
                request.UserId,
                request.AuditMissionId,
                request.ObjectiveActionId
            );

            if (!newActivity.IsSuccess)
            {
                return new BaseDTOResponse<BaseActivityDto>("Failed to create activity", false);
            }


            var result = await _activityRepository.AddAsync(newActivity.Value);
            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseActivityDto>("Failed to create activity", false);
            }

            return new BaseDTOResponse<BaseActivityDto>(mapper.Map<BaseActivityDto>(result.Value));
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseActivityDto>(e.Message, false);
        }
    }
}