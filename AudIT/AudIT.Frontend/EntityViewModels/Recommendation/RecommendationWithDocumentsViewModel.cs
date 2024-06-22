using Frontend.EntityViewModels.Documents;
using Frontend.EntityViewModels.ObjectiveAction;

namespace Frontend.EntityViewModels.Recommendation;

public class RecommendationWithDocumentsViewModel
{
    public BaseRecommendationViewModel Recommendation { get; set; }

    public List<BaseDocumentViewModel> Documents { get; set; }
}