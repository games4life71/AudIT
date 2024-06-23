﻿namespace Frontend.EntityDtos.Notification;

public class CreateNotificationDto
{
    public Guid RecommendationId { get; set; }

    public Guid InstitutionId { get; set; }

    public string Title { get; set; }

    public string? AdditionalInfo { get; set; }


}