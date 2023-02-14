using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Data.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace EbookStore.Domain.Repository;

public class UserRepository : IUserRepository
{
    #region Properties and constructors
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserRepository(
        UserManager<User> userManager,
        IMapper mapper)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    #endregion

    #region CreateAsync
    public async Task<UserRegisterResponse> CreateAsync(UserRegisterRequest request)
    {
        User user = _mapper.Map<User>(request);

        var result = await _userManager.CreateAsync(user, request.Password);
        var resultRole = await _userManager.AddToRoleAsync(user, "User");

        if (!result.Succeeded || !resultRole.Succeeded)
        {
            throw new Exception("Create user unsuccessfully!");
        }

        return _mapper.Map<UserRegisterResponse>(user);
    }
    #endregion

    #region IsDuplicateUserNameAsync
    public async Task<bool> IsDuplicateUserNameAsync(string username)
    {
        bool isDuplicate = false;
        User duplicateUser = await _userManager.FindByNameAsync(username);
        if (duplicateUser != null)
        {
            isDuplicate = true;
        }
        return isDuplicate;
    }
    #endregion

    #region FindUserFromLoginRequestAsync
    public async Task<User> FindUserFromLoginRequestAsync(UserLoginRequest request)
    {
        var user = await CheckUsername(request.UserName);
        await CheckPassword(user, request.Password);
        return user;
    }

    private async Task<User> CheckUsername(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            throw new Exception("Username or password is incorrect. Please try again");
        }
        else if (!user.IsActive)
        {
            throw new Exception("Your account is disabled. Please contact with IT Team");
        }

        return user;
    }

    private async Task CheckPassword(User user, string password)
    {
        var result = await _userManager.CheckPasswordAsync(user, password);
        if (!result)
        {
            throw new Exception("Username or password is incorrect. Please try again");
        }
    }
    #endregion

    #region GetUserRoleAsync
    public async Task<string> GetUserRoleAsync(User user)
        => (await _userManager.GetRolesAsync(user)).FirstOrDefault();
    #endregion
}
