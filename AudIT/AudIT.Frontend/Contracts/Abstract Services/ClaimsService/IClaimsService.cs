namespace Frontend.Contracts.Abstract_Services.ClaimsService;

public interface IClaimsService
{
    public Task<(Guid,bool)> GetUserIdFromTokenAsync(string token);
}