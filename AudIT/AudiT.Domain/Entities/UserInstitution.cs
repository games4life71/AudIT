using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

public class UserInstitution
{
    public Guid Id { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }

    public Guid InstitutionId { get; set; }

    public Institution Institution { get; set; }

    private UserInstitution(string userId, Guid institutionId, Institution institution)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        InstitutionId = institutionId;
        Institution = institution;
    }


    public UserInstitution()
    {
    }

    public static Result<UserInstitution> Create(string userId, Guid institutionId, Institution institution)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return Result<UserInstitution>.Failure("User Id is required");
        }


        return Result<UserInstitution>.Success(new UserInstitution(userId, institutionId, institution));
    }
}