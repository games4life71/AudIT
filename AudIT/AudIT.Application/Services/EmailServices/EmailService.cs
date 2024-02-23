using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Services.EmailServices;


/// <summary>
/// This class is responsible for sending emails to users.
/// </summary>
public class EmailService
{

    /// <summary>
    /// Sends an email to the institution responsible for authorizing the user.
    /// </summary>
    /// <returns></returns>
    public Task<bool> SendAuthorizeEmail(string adminId,User user )
    {


        //TODO Implement this method
        throw new NotImplementedException();


    }



}