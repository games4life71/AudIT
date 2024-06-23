using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Notification.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Queries.GetByInstitution;

public class GetNotificationsByInstitutionIdHandler(
    INotificationRepository notificationRepository,
    IMapper mapper
) : IRequestHandler<GetNotificationsByInstitutionIdQuery, BaseDTOResponse<BaseNotificationDto>>
{
    public async Task<BaseDTOResponse<BaseNotificationDto>> Handle(GetNotificationsByInstitutionIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var notifications = await notificationRepository.GetByInstitutionId(request.InstitutionId);

            if (!notifications.IsSuccess)
            {
                return new BaseDTOResponse<BaseNotificationDto>("No notifications found", false);
            }

            var notificationsDto = mapper.Map<List<BaseNotificationDto>>(notifications.Value);


            return new BaseDTOResponse<BaseNotificationDto>(notificationsDto, "Notifications found", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseNotificationDto>(e.Message, false);
        }
    }
}