using AudIT.Applicationa.Models.AuthDTO;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.Identity;

public interface IAuthService
{
    public Task<(int, string)> Registration(RegistrationModel model, string role);

    public Task<(int, string)> Login(LoginModel model);

    public Task<Result<List<User>>> GetAllUsersByInstitutionId(Guid institutionId);




}