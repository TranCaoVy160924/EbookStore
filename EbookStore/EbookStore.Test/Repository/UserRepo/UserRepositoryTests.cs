using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EbookStore.Test.Repository.UserRepo;

public class UserRepositoryTests
{
    private MockRepository mockRepository;

    private Mock<UserManager<User>> mockUserManager;
    private Mock<IConfiguration> mockConfiguration;
    private Mock<IMapper> mockMapper;

    public UserRepositoryTests()
    {
        this.mockRepository = new MockRepository(MockBehavior.Default);
        var store = new Mock<IUserStore<User>>();
        this.mockUserManager = this.mockRepository.Create<UserManager<User>>(
            store.Object, null, null, null, null, null, null, null, null);
        this.mockConfiguration = this.mockRepository.Create<IConfiguration>();
        this.mockMapper = this.mockRepository.Create<IMapper>();
    }

    private UserRepository CreateUserRepository()
    {
        return new UserRepository(
            this.mockUserManager.Object,
            this.mockConfiguration.Object,
            this.mockMapper.Object);
    }

    [Fact]
    public async Task CreateAsync_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var userRepository = this.CreateUserRepository();
        UserRegisterRequest request = null;

        // Act
        var result = await userRepository.CreateAsync(
            request);

        // Assert
        Assert.True(false);
        this.mockRepository.VerifyAll();
    }

    [Fact]
    public async Task IsDuplicateUserNameAsync_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var userRepository = this.CreateUserRepository();
        string username = null;

        // Act
        var result = await userRepository.IsDuplicateUserNameAsync(
            username);

        // Assert
        Assert.True(false);
        this.mockRepository.VerifyAll();
    }

    [Fact]
    public async Task FindUserFromLoginRequestAsync_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var userRepository = this.CreateUserRepository();
        UserLoginRequest request = null;

        // Act
        var result = await userRepository.FindUserFromLoginRequestAsync(
            request);

        // Assert
        Assert.True(false);
        this.mockRepository.VerifyAll();
    }

    [Fact]
    public async Task CreateToken_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var userRepository = this.CreateUserRepository();
        User user = null;

        // Act
        var result = await userRepository.CreateToken(
            user);

        // Assert
        Assert.True(false);
        this.mockRepository.VerifyAll();
    }
}
