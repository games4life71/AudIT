using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Identity;

namespace AudiT.Domain.Entities;

public class User : IdentityUser
{
    public string FirstEmail { get; private set; }

    public string? SecondEmail { get; private set; }

    public string Adress { get; private set; }

    public string? PhoneNumber { get; private set; }

    public string? OfficePhoneNumber { get; private set; }

    public string? Functie { get; private set; } //TODO mai bine e un enum din care se alege functia

    public Department? Department { get; private set; }

    // public Institution? Institution { get; private set; }
    //
    //  public Guid? InstitutionId { get; set; }
    //
    public bool Verified { get; private set; } = false;


    // public void SetInstitutionId(Guid id)
    // {
    //     InstitutionId = id;
    // }
    public User()
    {
    }

    private User(
        string username,
        string firstEmail,
        string secondEmail,
        string adress,
        string phoneNumber,
        string functie,
        string officephone,
        Department department
    )
    {
        // Id = Guid.NewGuid().ToString();
        UserName = username;
        FirstEmail = firstEmail;
        Email = firstEmail;
        SecondEmail = secondEmail;
        Adress = adress;
        PhoneNumber = phoneNumber;
        Functie = functie;
        OfficePhoneNumber = officephone;
        Department = department;
    }

    public static Result<User> Create(string username, string firstEmail, string adress,
        string phoneNumber, Department department = null, string functie = "not set",
        string secondEmail = "not set",
        string officephone = "not set")
    {
        //TODO make all the checks then construct the entity

        if (string.IsNullOrEmpty(username))
        {
            return Result<User>.Failure("Username is required");
        }

        if (string.IsNullOrEmpty(firstEmail))
        {
            return Result<User>.Failure("First email is required");
        }


        if (string.IsNullOrEmpty(adress))
        {
            return Result<User>.Failure("Adress is required");
        }

        if (string.IsNullOrEmpty(phoneNumber))
        {
            return Result<User>.Failure("Phone number is required");
        }

        if (secondEmail == firstEmail)
        {
            return Result<User>.Failure("Second email cannot be the same as the first email");
        }


        return Result<User>.Success(
            new User(
                username,
                firstEmail,
                secondEmail,
                adress,
                phoneNumber,
                functie,
                officephone,
                department
            ));
    }

    public bool VerifyUser()
    {
        Verified = true;
        return Verified;
    }

    public void UpdateUserInfo(string secondEmail, string adress, string phoneNumber, string officePhoneNumber,
        string functie,string username)
    {
        SecondEmail = secondEmail;
        Adress = adress;
        PhoneNumber = phoneNumber;
        OfficePhoneNumber = officePhoneNumber;
        Functie = functie;
        UserName = username;
    }
}