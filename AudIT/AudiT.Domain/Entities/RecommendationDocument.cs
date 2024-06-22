using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

public class RecommendationDocument : AuditableEntity
{
    public Guid Id { get; set; }

    public Recommendation Recommendation { get; set; }

    public Guid RecommendationId { get; set; }

    public BaseDocument BaseDocument { get; set; }

    public Guid BaseDocumentId { get; set; }

    private RecommendationDocument(Guid recommendationId, Guid baseDocumentId)
    {
        RecommendationId = recommendationId;

        BaseDocumentId = baseDocumentId;
    }

    public RecommendationDocument()
    {
    }

    public static Result<RecommendationDocument> Create(Guid recommendationId, Guid baseDocumentId)
    {
        //TODO : Add validation logic here
        return Result<RecommendationDocument>.Success(new RecommendationDocument(recommendationId, baseDocumentId));
    }
}