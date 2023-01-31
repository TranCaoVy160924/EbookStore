using AutoMapper;
using EbookStore.Contract.Model;
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
    private readonly EbookStoreDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserRepository(
        EbookStoreDbContext dbContext,
        UserManager<User> userManager,
        IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _userManager = userManager;
    }

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
}
