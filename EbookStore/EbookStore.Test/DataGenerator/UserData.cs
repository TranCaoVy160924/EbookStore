using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Test.DataGenerator;

public static class UserData
{
    public static UserRegisterRequest CreateValidRegisterRequest()
    {
        return new UserRegisterRequest
        {
            UserName = "test",
            FirstName = "test",
            LastName = "test",
            Password = "test",
            ConfirmPassword = "test",
            Email = "test",
            PhoneNumber = "test",
        };
    }

    public static User CreateActiveUser()
    {
        return new User
        {
            UserName = "test",
            FirstName = "test",
            LastName = "test",
            Email = "test",
            PhoneNumber = "test",
            IsActive = true,
            ConcurrencyStamp = (new DateTime(2002, 10, 12)).ToString()
        };
    }

    public static User CreateInactiveUser()
    {
        return new User
        {
            UserName = "test",
            FirstName = "test",
            LastName = "test",
            Email = "test",
            PhoneNumber = "test",
            IsActive = false,
            ConcurrencyStamp = (new DateTime(2002, 10, 12)).ToString()
        };
    }

    public static UserLoginRequest CreateValidLoginRequest()
    {
        return new UserLoginRequest
        {
            UserName = "test",
            Password = "test"
        };
    }
}
