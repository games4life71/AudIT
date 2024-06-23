using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.InstitutionsService;
using Frontend.EntityDtos.Institution;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Institution;
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

    public async Task<BaseDTOResponse<InstitutionFullViewModel>> GetAllInstitutionsFullAsync()
    {
        var response = await _httpClient.GetAsync($"{IInstitutionService.ApiPath}/get-all-institutions-full");


        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<InstitutionFullViewModel>("Error while fetching data for institutions", false);
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<BaseDTOResponse<InstitutionFullViewModel>>(content);

        if (result != null) return result;

        return new BaseDTOResponse<InstitutionFullViewModel>("Error while fetching data for institutions", false);
    }

    public async Task<BaseResponse> DeleteInstitutionAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{IInstitutionService.ApiPath}/delete-institution/{id}");


        if (!response.IsSuccessStatusCode)
        {
            return new BaseResponse("Error while deleting institution", false);
        }

        return new BaseResponse("Institution deleted successfully", true);
    }

    public async Task<BaseDTOResponse<BaseInstitutionDto>> AddInstitutionAsync(CreateInstitutionDto institution)
    {
        var response = await _httpClient.PostAsJsonAsync($"{IInstitutionService.ApiPath}/add-institution", institution);


        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseInstitutionDto>("Error while adding institution", false);
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseInstitutionDto>>(content);

        if (result != null) return result;

        return new BaseDTOResponse<BaseInstitutionDto>("Error while adding institution", false);
    }

    public async Task<BaseDTOResponse<InstitutionFullViewModel>> EditInstitutionAsync(EditInstitutionDto institution)
    {
        var response = await _httpClient.PutAsJsonAsync($"{IInstitutionService.ApiPath}/edit-institution", institution);


        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<InstitutionFullViewModel>>(content);

            if (result != null) return result;
        }

        return new BaseDTOResponse<InstitutionFullViewModel>("Error while editing institution", false);
    }

     public async  Task<BaseDTOResponse<BaseInstitutionDto>> GetInstitutionByRecommendationAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"{IInstitutionService.ApiPath}/get-institution-by-recommendation/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseInstitutionDto>("Error while fetching data for institutions", false);
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseInstitutionDto>>(content);

        if (result != null) return result;

        return new BaseDTOResponse<BaseInstitutionDto>("Error while fetching data for institutions", false);
    }
}