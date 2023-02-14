using EbookStore.Contract.Model;
using EbookStore.Test.DataGenerator;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Test.Mocker.UserRepoMocker;

public static class UserManagerMocker
{
    public static Mock<UserManager<User>> CreateMockUserManager(MockRepository mockRepository)
    {
        var store = new Mock<IUserStore<User>>();
        return mockRepository.Create<UserManager<User>>(
            store.Object, null, null, null, null, null, null, null, null);
    }

    #region CreateAsync
    public static void SetSuccessCreateAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
    }

    public static void SetFailCreateAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed(new IdentityError()));
    }
    #endregion

    #region AddToRoleAsync
    public static void SetSuccessAddToRoleAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
    }

    public static void SetFailAddToRoleAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed(new IdentityError()));
    }
    #endregion

    #region FindByNameAsync
    public static void SetSuccessFindByNameAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.FindByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(UserData.CreateActiveUser());
    }

    public static void SetInactiveFindByNameAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.FindByNameAsync(It.IsAny<string>()))
            .ReturnsAsync(UserData.CreateInactiveUser());
    }

    public static void SetFailFindByNameAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.FindByNameAsync(It.IsAny<string>()))
            .ReturnsAsync((User)null);
    }
    #endregion

    #region CheckPasswordAsync
    public static void SetSuccessCheckPasswordAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
            .ReturnsAsync(true);
    }

    public static void SetFailCheckPasswordAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
            .ReturnsAsync(false);
    }
    #endregion

    #region GetRolesAsync
    public static void SetGetRoleAsync(this Mock<UserManager<User>> mockUsermanager)
    {
        mockUsermanager.Setup(mu => mu.GetRolesAsync(It.IsAny<User>()))
            .ReturnsAsync(new List<string> { "User" });
    }
    #endregion
}
