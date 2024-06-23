using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Notification.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Commands.Create;

public class CreateNotificationHandler(
    INotificationRepository notificationRepository,
    IRecommendationRepository recommendationRepository,
    IInstitutionRepository institutionRepository,
    IMapper mapper
) : IRequestHandler<CreateNotificationCommand, BaseDTOResponse<BaseNotificationDto>>
{
    public async Task<BaseDTOResponse<BaseNotificationDto>> Handle(CreateNotificationCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var recommendation = await recommendationRepository.FindByIdAsync(request.RecommendationId);

            if (!recommendation.IsSuccess)
            {
                return new BaseDTOResponse<BaseNotificationDto>("Recommendation not found", false);
            }

            var institution = await institutionRepository.FindByIdAsync(request.InstitutionId);

            if (!institution.IsSuccess)
            {
                return new BaseDTOResponse<BaseNotificationDto>("Institution not found", false);
            }

            var notification = AudiT.Domain.Entities.Notification
                .Create(
                    request.Title,
                    request.AdditionalInfo,
                    request.RecommendationId,
                    request.InstitutionId,
                    request.NotificationType
                );


            if (!notification.IsSuccess)
            {
                return new BaseDTOResponse<BaseNotificationDto>("Failed to create notification", false);
            }

            var result = await notificationRepository.AddAsync(notification.Value);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseNotificationDto>("Failed to create notification", false);
            }

            var notificationDto = mapper.Map<BaseNotificationDto>(notification.Value);

            return new BaseDTOResponse<BaseNotificationDto>(notificationDto, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseNotificationDto>("Failed to create notification", false);
        }
    }
}