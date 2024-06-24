using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.EntityAccesService;
using Frontend.EntityDtos.EntityAcces;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.EntityAccess;
using Newtonsoft.Json;

namespace Frontend.Services.EntityAcces;

public class EntityAccesService(HttpClient httpClient) : IEntityAccesService
{
    public async Task<BaseDTOResponse<BaseEntityAccesViewModel>> CreateEntityAccesAsync(
        BaseCreateEntityaAccesDto entityAccesViewModel)
    {
        var response = await httpClient.PostAsJsonAsync($"{IEntityAccesService.BaseUrl}/create-entity-acces",
            entityAccesViewModel);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseEntityAccesViewModel>>(content);

            if (result != null) return result;
        }

        return new BaseDTOResponse<BaseEntityAccesViewModel>
        {
            Success = false,
            Message = "An error occurred while creating entity access"
        };
    }
}