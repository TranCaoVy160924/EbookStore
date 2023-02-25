using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Data.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Security.Claims;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.User.Response;
using EbookStore.Contract.ViewModel.User.Request;
using EbookStore.Domain.Utilities;

namespace EbookStore.Domain.Repository;

public class UserRepository : IUserRepository
{
    #region Properties and constructors
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private EbookStoreDbContext _dbContext;

    public UserRepository(
        UserManager<User> userManager,
        IConfiguration config,
        IMapper mapper,
        EbookStoreDbContext dbContext)
    {
        _mapper = mapper;
        _config = config;
        _userManager = userManager;
        _dbContext = dbContext;
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

    #region CreateTokenAsync
    public async Task<string> CreateTokenAsync(User user)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user, user.Id,user.UserName, await GetUserRoleAsync(user));
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    private IList<Claim> GetClaims(User user, Guid userid, string username, string role)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Sid, userid.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
            };

        return claims;
    }

    private async Task<string> GetUserRoleAsync(User user)
        => (await _userManager.GetRolesAsync(user)).FirstOrDefault();

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IList<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
            (issuer: _config["JwtSettings:validIssuer"],
            audience: _config["JwtSettings:validIssuer"],
            claims: claims,
            expires: DateTime.Now.AddHours(int.Parse(_config["JwtSettings:expires"])),
            signingCredentials: signingCredentials);
        return tokenOptions;
    }
    #endregion

    #region GetUsers
    public async Task<PagedList<UserQueryResponse>> GetUsersAsync(UserQueryRequest queryRequest)
    {
        IQueryable<User> query = _dbContext.Users.Where(u => u.UserName.Contains(queryRequest.UserName));
        var paginatedResult = await query.PaginateResultAsync(queryRequest);

        var result = paginatedResult.MapResultToResponse<User, UserQueryResponse>(_mapper);
        int count = (result.CurrentPage - 1) * result.PageSize;
        foreach (var userResponse in result.Data) { userResponse.UserId = ++count; };
         
        return result;
    }
    #endregion
}
