using AudIT.Applicationa.Models.AuthDTO;

namespace AudIT.Applicationa.Contracts.Identity;

public interface IAuthService
{
    public Task<(int, string)> Registration(RegistrationModel model, string role);

    public Task<(int, string)> Login(LoginModel model);
}