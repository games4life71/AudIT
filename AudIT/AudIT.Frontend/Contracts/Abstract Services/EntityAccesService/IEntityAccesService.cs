using Frontend.EntityDtos.EntityAcces;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.EntityAccess;

namespace Frontend.Contracts.Abstract_Services.EntityAccesService;

public interface IEntityAccesService
{

    public const string BaseUrl = "https://localhost:7248/api/EntityAcces";
    public Task<BaseDTOResponse<BaseEntityAccesViewModel>> CreateEntityAccesAsync(BaseCreateEntityaAccesDto entityAccesDto);

    public Task<BaseDTOResponse<BaseEntityAccesViewModel>> GetEntityAccesByUserIdAsync(Guid userId);

    public Task<BaseDTOResponse<EntityAccessWithUserInfoViewModel>> GetAccesGrantedByUserAsync();

    public Task<BaseResponse> RemoveEntityAccesAsync(Guid id);
}