﻿using Infrastructure.Identity;
using Xunit;

namespace xUnitTests.Services;
public class UserServiceTest
{
    [Fact]
    public void IsUserConfirmedShouldReturnTrueWhenInputIsTrue()
    {

        //Arrange

        ApplicationUser user = new ApplicationUser();
        user.UserName = "Test";
        user.EmailConfirmed = true;

        UserService service = new UserService();

        //Act

        bool isEmailConfirmed = service.IsUserEmailConfirmed(user);

        //Assert
        Assert.True(isEmailConfirmed);
    }

    [Fact]
    public void IsUserConfirmedShouldReturnFalseWhenInputIsFalse()
    {

        //Arrange

        ApplicationUser user = new ApplicationUser();
        user.UserName = "Test";
        user.EmailConfirmed = false;

        UserService service = new UserService();

        //Act

        bool isEmailConfirmed = service.IsUserEmailConfirmed(user);

        //Assert
        Assert.False(isEmailConfirmed);
    }
}
