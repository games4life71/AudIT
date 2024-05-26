using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class RegisterModel
{
    [Required] public string userName { get; set; }
    [Required] public string address { get; set; }

    [Required] public string phoneNumber { get; set; }
    [Required] [EmailAddress] public string emailAddress { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

}