using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Commands.Update;

public class UpdateRecommendationCommmand:IRequest<BaseDTOResponse<BaseRecommendationDTO>>
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public Status Status { get; set; }

    public string Problem { get; set; }

    public string? AditionalFindings { get; set; }

    public string? Cause { get; set; }

    public string? Consequence { get; set; }

    public string RecommendationDescription { get; set; }


    public UpdateRecommendationCommmand(Guid id, string description, DateTime dueDate, Status status, string problem, string? aditionalFindings, string? cause, string? consequence, string recommendationDescription)
    {
        Id = id;
        Description = description;
        DueDate = dueDate;
        Status = status;
        Problem = problem;
        AditionalFindings = aditionalFindings;
        Cause = cause;
        Consequence = consequence;
        RecommendationDescription = recommendationDescription;
    }
}