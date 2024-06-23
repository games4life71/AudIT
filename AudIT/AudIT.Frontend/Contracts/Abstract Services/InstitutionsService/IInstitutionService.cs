using Frontend.EntityDtos.Institution;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Institution;

namespace Frontend.Contracts.Abstract_Services.InstitutionsService;

public interface IInstitutionService
{
    const string ApiPath = "http://localhost:5071/api/v1/Institution";

    public Task<BaseDTOResponse<BaseInstitutionDto>> GetAllInstitutionsAsync();
    public Task<BaseDTOResponse<InstitutionFullViewModel>> GetAllInstitutionsFullAsync();

    public Task<BaseResponse> DeleteInstitutionAsync(Guid id);

    public Task<BaseDTOResponse<BaseInstitutionDto>> AddInstitutionAsync(CreateInstitutionDto institution);

    public Task<BaseDTOResponse<InstitutionFullViewModel>> EditInstitutionAsync(EditInstitutionDto institution);

    public Task<BaseDTOResponse<BaseInstitutionDto>> GetInstitutionByRecommendationAsync(Guid id);
}