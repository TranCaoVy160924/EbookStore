using AutoMapper;
using EbookStore.Contract.Mapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Domain.Repository;
using EbookStore.Test.DataGenerator;
using EbookStore.Test.Mocker.MapperMocker;
using EbookStore.Test.Mocker.UserRepoMocker;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EbookStore.Test.Repository.UserRepo;

public class UserRepositoryTests
{
    #region Properties and constructors
    private readonly MockRepository _mockRepository;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    public UserRepositoryTests()
    {
        _mockRepository = new MockRepository(MockBehavior.Default);
        _config = ConfigMocker.CreateConfig(_mockRepository);
        _mapper = MapperMocker.CreateMapper();
    }
    #endregion

    #region CreateAsync
    [Fact]
    public async Task CreateAsync_ValidInput_ReturnNewlyCreatedUser()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetSuccessCreateAsync();
        mockUserManager.SetSuccessAddToRoleAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        UserRegisterRequest request = UserData.CreateValidRegisterRequest();

        User user = _mapper.Map<User>(request);
        string expectedResult = JsonConvert.SerializeObject(_mapper.Map<UserRegisterResponse>(user));

        // Act
        string result = JsonConvert.SerializeObject(await userRepository.CreateAsync(request));

        // Assert
        Assert.Equal(expectedResult, result);
        _mockRepository.VerifyAll();
    }

    [Fact]
    public async Task CreateAsync_CreateFail_ThrowException()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetFailCreateAsync();
        mockUserManager.SetSuccessAddToRoleAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        UserRegisterRequest request = UserData.CreateValidRegisterRequest();

        // Assert
        Exception exception
            = await Assert.ThrowsAsync<Exception>(() => userRepository.CreateAsync(request));
        Assert.Equal("Create user unsuccessfully!", exception.Message);
        _mockRepository.VerifyAll();
    }

    [Fact]
    public async Task CreateAsync_AddToRoleFail_ThrowException()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetSuccessCreateAsync();
        mockUserManager.SetFailAddToRoleAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        UserRegisterRequest request = UserData.CreateValidRegisterRequest();

        // Assert
        Exception exception
            = await Assert.ThrowsAsync<Exception>(() => userRepository.CreateAsync(request));
        Assert.Equal("Create user unsuccessfully!", exception.Message);
        _mockRepository.VerifyAll();
    }
    #endregion

    #region IsDuplicateUserNameAsync
    [Fact]
    public async Task IsDuplicateUserNameAsync_NoDuplicate_ReturnFalse()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetFailFindByNameAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        string username = "";

        // Act
        var result = await userRepository.IsDuplicateUserNameAsync(username);

        // Assert
        Assert.False(result);
        _mockRepository.VerifyAll();
    }

    [Fact]
    public async Task IsDuplicateUserNameAsync_Duplicate_ReturnTrue()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetSuccessFindByNameAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        string username = "";

        // Act
        var result = await userRepository.IsDuplicateUserNameAsync(username);

        // Assert
        Assert.True(result);
        _mockRepository.VerifyAll();
    }
    #endregion

    #region FindUserFromLoginRequestAsync
    [Fact]
    public async Task FindUserFromLoginRequestAsync_Success_ReturnUser()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetSuccessFindByNameAsync();
        mockUserManager.SetSuccessCheckPasswordAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        UserLoginRequest request = UserData.CreateValidLoginRequest();
        string expectedResult = JsonConvert.SerializeObject(UserData.CreateActiveUser());

        // Act
        string result
            = JsonConvert.SerializeObject(await userRepository.FindUserFromLoginRequestAsync(request));

        // Assert
        Assert.Equal(expectedResult, result);
        _mockRepository.VerifyAll();
    }

    [Fact]
    public async Task FindUserFromLoginRequestAsync_NoUser_ThrowException()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetFailFindByNameAsync();
        mockUserManager.SetSuccessCheckPasswordAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        UserLoginRequest request = UserData.CreateValidLoginRequest();
        string expectedResult = JsonConvert.SerializeObject(UserData.CreateActiveUser());

        // Assert
        Exception exception = await Assert.ThrowsAsync<Exception>(
            () => userRepository.FindUserFromLoginRequestAsync(request));
        Assert.Equal("Username or password is incorrect. Please try again", exception.Message);
    }

    [Fact]
    public async Task FindUserFromLoginRequestAsync_WrongPassword_ThrowException()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetSuccessFindByNameAsync();
        mockUserManager.SetFailCheckPasswordAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        UserLoginRequest request = UserData.CreateValidLoginRequest();
        string expectedResult = JsonConvert.SerializeObject(UserData.CreateActiveUser());

        // Assert
        Exception exception = await Assert.ThrowsAsync<Exception>(
            () => userRepository.FindUserFromLoginRequestAsync(request));
        Assert.Equal("Username or password is incorrect. Please try again", exception.Message);
    }

    [Fact]
    public async Task FindUserFromLoginRequestAsync_UserInactive_ThrowException()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetInactiveFindByNameAsync();
        mockUserManager.SetSuccessCheckPasswordAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        UserLoginRequest request = UserData.CreateValidLoginRequest();
        string expectedResult = JsonConvert.SerializeObject(UserData.CreateActiveUser());

        // Assert
        Exception exception = await Assert.ThrowsAsync<Exception>(
            () => userRepository.FindUserFromLoginRequestAsync(request));
        Assert.Equal("Your account is disabled. Please contact with IT Team", exception.Message);
    }
    #endregion

    #region CreateTokenAsync
    [Fact]
    public async Task CreateTokenAsync_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        Mock<UserManager<User>> mockUserManager
            = UserManagerMocker.CreateMockUserManager(_mockRepository);
        mockUserManager.SetGetRoleAsync();

        var userRepository = new UserRepository(mockUserManager.Object, _config, _mapper);
        User user = UserData.CreateActiveUser();

        // Act
        var result = await userRepository.CreateTokenAsync(user);

        // Assert
        Assert.IsType<string>(result);
        _mockRepository.VerifyAll();
    }
    #endregion
}
