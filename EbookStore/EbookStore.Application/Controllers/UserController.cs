using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Data.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static EbookStore.Application.ValidateHelper;

namespace EbookStore.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController  : ControllerBase
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    public UserController(
        EbookStoreDbContext dbContext,
        UserManager<User> userManager,
        IConfiguration config,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _config = config;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest registerRequest)
    {
        if (!Validate(registerRequest))
        {
            return BadRequest("Invalid Request");
        }

        var duplicateUser = await _userManager.FindByNameAsync(registerRequest.UserName);
        if (duplicateUser != null)
        {
            return BadRequest("User already exist");
        }

        var user = new User
        {
            FirstName = registerRequest.FirstName.Trim(),
            LastName = registerRequest.LastName.Trim(),
            UserName = registerRequest.UserName.Trim(),
            Email = registerRequest.Email.Trim(),
            PhoneNumber = registerRequest.PhoneNumber.Trim(),
            SecurityStamp = registerRequest.FirstName,
            IsActive = true
        };

        var result = await _userManager.CreateAsync(user, registerRequest.Password);
        var resultRole = await _userManager.AddToRoleAsync(user, "User");

        if (result.Succeeded && resultRole.Succeeded)
        {
            return Ok(_mapper.Map<UserRegisterResponse>(user));
        }

        return BadRequest("Create user unsuccessfully!");
    }

    [HttpPost("auth/token/")]
    public async Task<IActionResult> Authenticate([FromBody] UserLoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user == null)
        {
            return BadRequest("Username or password is incorrect. Please try again");
        }
        else if (!user.IsActive)
        {
            return BadRequest("Your account is disabled. Please contact with IT Team");
        }

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            return BadRequest("Username or password is incorrect. Please try again");
        }

        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        //var role = await _dbContext.AppRoles.FindAsync(user.RoleId);
        //StaticValues.Usernames.Add(request.Username);
        return Ok(CreateToken(user, request.UserName, role));
    }

    //[HttpGet("auth/user-profile/")]
    //[Authorize]
    //public async Task<IActionResult> GetUserProfile()
    //{
    //    var result = await _userManager.FindByNameAsync(User.Identity.Name);
    //    var data = _mapper.Map<UserResponse>(result);

    //    return Ok(data);
    //}

    //[HttpPost("auth/change-password/")]
    //[Authorize]
    //public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    var user = await _userManager.FindByNameAsync(User.Identity.Name);

    //    var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

    //    if (!result.Succeeded)
    //    {
    //        return BadRequest(result.Errors);
    //    }

    //    user.IsLoginFirstTime = false;

    //    await _userManager.UpdateAsync(user);

    //    return Ok(new SuccessResponseResult<string>("Change password success!"));
    //}

    private string CreateToken(User user, string username, string role)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user, username, role);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private IList<Claim> GetClaims(User user, string username, string role)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
            };

        return claims;
    }

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

    private SigningCredentials GetSigningCredentials()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }
}
