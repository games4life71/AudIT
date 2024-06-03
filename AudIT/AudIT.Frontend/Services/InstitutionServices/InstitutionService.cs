using Frontend.Contracts.Abstract_Services.InstitutionsService;
using Frontend.EntityDtos.Institution;
using Frontend.EntityDtos.Misc;
using Newtonsoft.Json;

namespace Frontend.Services.InstitutionServices;

public class InstitutionService(HttpClient _httpClient) : IInstitutionService
{
    public async Task<BaseDTOResponse<BaseInstitutionDto>> GetAllInstitutionsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{IInstitutionService.ApiPath}/get-all-institutions");

            if (!response.IsSuccessStatusCode)
            {
                return new BaseDTOResponse<BaseInstitutionDto>("Error while fetching data for institutions", false);
            }

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseInstitutionDto>>(content);

            if (result != null) return result;


            return new BaseDTOResponse<BaseInstitutionDto>("Error while fetching data for institutions", false);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseInstitutionDto>(e.Message, false);
        }
    }
}