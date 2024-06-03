using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTesting.DomainTests.Entities;

public class UserTests
{
    [Fact]
    public void Check_User_Creation_With_Complete_Data()
    {
        //Arrange
        var username = "test";
        var firstEmail = "email@google.com";
        var secondEmail = "email@google.com";
        var adress = "adress";
        var phoneNumber = "123456789";


        //Act

        var newUser = User.Create(username, firstEmail, adress, phoneNumber) ?? throw new ArgumentNullException("User.Create(username, firstEmail, adress, phoneNumber)");


        //Assert
        newUser.IsSuccess.Should().BeTrue();
        newUser.Value.UserName.Should().Be(username);
        newUser.Value.FirstEmail.Should().Be(firstEmail);
        newUser.Value.Adress.Should().Be(adress);
        newUser.Value.PhoneNumber.Should().Be(phoneNumber);
    }

    [Fact]
    public void Check_User_Creation_With_Incomplete_Data()
    {
        //Arrange
        var username = "test";
        var adress = "adress";
        var phoneNumber = "123456789";

        //Act
        var newUser = User.Create(username, "", adress, phoneNumber);

        //Assert
        newUser.IsSuccess.Should().BeFalse();
        newUser.Error.Should().Be("First email is required");
    }

    [Fact]
    public void Check_User_Creation_With_Incomplete_Data_2()
    {
        //Arrange
        var username = "test";
        var firstEmail = "email@google.com";
        var adress = "adress";

        var new_user = User.Create(username, firstEmail, adress, "");


        //Assert
        new_user.IsSuccess.Should().BeFalse();
        new_user.Error.Should().Be("Phone number is required");
    }

    [Fact]
    public void Check_User_Creation_With_Same_Emails()
    {
        //Arrange
        var username = "test";
        var firstEmail = "email@google.com";
        var address = "adress";
        var phoneNumber = "12345678";

        //Act
        var newUser = User.Create(username, firstEmail, address, phoneNumber, secondEmail: firstEmail);

        //Assert

        newUser.IsSuccess.Should().BeFalse();
        newUser.Error.Should().Be("Second email cannot be the same as the first email");
    }

    [Theory]
    [InlineData("test", "email@com", "email2@com", "adress", "123456789", "functie", "123456789")]
    public void Check_User_Creation_With_Optional_Complete_Data(string username, string firstEmail, string secondEmail,
        string adress, string phoneNumber, string functie, string officephone)
    {
        //Arrange
        var NewDepatment = Department.Create("mock", "mock", "mock", null);


        //Act
        var newUser = User.Create(username, firstEmail, adress, phoneNumber, NewDepatment.Value, functie, secondEmail,
            officephone);

        //Assert
        newUser.IsSuccess.Should().BeTrue();
        newUser.Value.UserName.Should().Be(username);
        newUser.Value.FirstEmail.Should().Be(firstEmail);
        newUser.Value.SecondEmail.Should().Be(secondEmail);
        newUser.Value.Adress.Should().Be(adress);
        newUser.Value.PhoneNumber.Should().Be(phoneNumber);
        newUser.Value.Functie.Should().Be(functie);
        newUser.Value.OfficePhoneNumber.Should().Be(officephone);
    }


}