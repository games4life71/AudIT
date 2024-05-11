using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Commands.Update;

public class UpdateActivityHandler(
    IActivityRepository activityRepository,
    IAuditMissionRepository auditMissionRepository,
    IObjectiveActionRepository objectiveActionRepository,
    IDepartmentRepository departmentRepository,
    IMapper mapper
) : IRequestHandler<UpdateActivityCommand, BaseDTOResponse<BaseActivityDto>>
{
    public async Task<BaseDTOResponse<BaseActivityDto>> Handle(UpdateActivityCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var activity = await activityRepository.FindByIdAsync(request.Id);


            var department = await departmentRepository.FindByIdAsync(request.DepartmentId);
            var auditMission = await auditMissionRepository.FindByIdAsync(request.AuditMissionId);
            var objectiveAction = await objectiveActionRepository.FindByIdAsync(request.ObjectiveActionId.Value);


            if (!department.IsSuccess)
            {
                return new BaseDTOResponse<BaseActivityDto>
                {
                    Success = false,
                    Message = $"Failed to find department with id {request.DepartmentId}"
                };
            }

            if (!auditMission.IsSuccess)
            {
                return new BaseDTOResponse<BaseActivityDto>
                {
                    Success = false,
                    Message = $"Failed to find audit mission with id {request.AuditMissionId}"
                };
            }

            if (!objectiveAction.IsSuccess)
            {
                return new BaseDTOResponse<BaseActivityDto>
                {
                    Success = false,
                    Message = $"Failed to find objective action with id {request.ObjectiveActionId}"
                };
            }

            if (!activity.IsSuccess)
            {
                return new BaseDTOResponse<BaseActivityDto>
                {
                    Success = false,
                    Message = $"Failed to find activity with id {request.Id}"
                };
            }


            activity.Value.Update(
                name: request.Name,
                type: request.Type,
                departmentId: request.DepartmentId,
                auditMissionId: request.AuditMissionId,
                objectiveActionId: request.ObjectiveActionId,
                department: activity.Value.Department
            );


            var result = await activityRepository.UpdateAsync(activity.Value);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseActivityDto>
                {
                    Success = false,
                    Message = $"Failed to update activity with id {request.Id}"
                };
            }

            return new BaseDTOResponse<BaseActivityDto>
            {
                Success = true,
                DtoResponse = mapper.Map<BaseActivityDto>(activity.Value),
                Message = $"Activity with id {request.Id} updated successfully"
            };
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseActivityDto>
            {
                Success = false,
                Message = $"An error occurred : {e.Message}"
            };
        }
    }
}