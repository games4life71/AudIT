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

    public bool Verified { get; private set; } = false;
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
        Department department)
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
        string phoneNumber, Department department = null, string functie = "not set", string secondEmail = "not set",
        string officephone = "not set")
    {
        //TODO make all the checks then construct the entity

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
}