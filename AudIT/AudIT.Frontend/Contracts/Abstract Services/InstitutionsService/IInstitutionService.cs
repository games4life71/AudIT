using Frontend.EntityDtos.Institution;
using Frontend.EntityDtos.Misc;

namespace Frontend.Contracts.Abstract_Services.InstitutionsService;

public interface IInstitutionService
{
    const string ApiPath = "http://localhost:5071/api/v1/Institution";

    public Task<BaseDTOResponse<BaseInstitutionDto>> GetAllInstitutionsAsync();

}