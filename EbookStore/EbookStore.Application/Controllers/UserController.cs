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

    [HttpGet]
    public async Task<IActionResult> Login([FromQuery] UserLoginRequest userLoginRequest)
    {
        if (AuthenticateUser(userLoginRequest) != null)
        {
            string jwtToken = GenerateJSONWebToken(userLoginRequest).ToString();
            return Ok(jwtToken);
        }
        return Unauthorized();
    }

    private string GenerateJSONWebToken(UserLoginRequest userLoginRequest)
    {
        var builder = WebApplication.CreateBuilder();
        var issuer = builder.Configuration["JwtSettings:validIssuer"];
        var audience = builder.Configuration["JwtSettings:validIssuer"];
        var key = Encoding.ASCII.GetBytes
        (builder.Configuration["JwtSettings:key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userLoginRequest.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
            Expires = DateTime.UtcNow.AddMinutes(60),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }

    private UserLoginRequest? AuthenticateUser(UserLoginRequest userLoginRequest)
    {
        var users = _userManager.Users.ToList();
        foreach (var user in users)
        {
            if (userLoginRequest.UserName == user.UserName &&
                userLoginRequest.Password == user.PasswordHash)
            {
                return userLoginRequest;
            }
        }
        return null;
    }

    //[HttpGet]
    //public async Task<IActionResult> Authenticate([FromQuery] UserLoginRequest userLoginRequest)
    //{
    //    if (AuthenticateUser(userLoginRequest) != null)
    //    {
    //        var user = await _userManager.FindByNameAsync(userLoginRequest.UserName);
    //        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
    //        //var role = await _dbContext.AppRoles.FindAsync(user.RoleId);
    //        return Ok(CreateToken(user, userLoginRequest.UserName, role));
    //    }
    //    return Unauthorized();
    //}

    //private UserLoginRequest? AuthenticateUser(UserLoginRequest userLoginRequest)
    //{
    //    var users = _userManager.Users.ToList();
    //    foreach (var user in users)
    //    {
    //        if (userLoginRequest.UserName == user.UserName &&
    //            userLoginRequest.Password == user.PasswordHash)
    //        {
    //            return userLoginRequest;
    //        }
    //    }
    //    return null;
    //}

    //private string CreateToken(User user, string username, string role)
    //{
    //    var signingCredentials = GetSigningCredentials();
    //    var claims = GetClaims(user, username, role);
    //    var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

    //    return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    //}

    //private IList<Claim> GetClaims(User user, string username, string role)
    //{
    //    var claims = new List<Claim>
    //        {
    //            new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
    //            new Claim(ClaimTypes.Name, username),
    //            new Claim(ClaimTypes.Role, role)
    //        };

    //    return claims;
    //}

    //private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IList<Claim> claims)
    //{
    //    var tokenOptions = new JwtSecurityToken
    //        (issuer: _config["JwtSettings:validIssuer"],
    //        audience: _config["JwtSettings:validIssuer"],
    //        claims: claims,
    //        expires: DateTime.Now.AddHours(int.Parse(_config["JwtSettings:expires"])),
    //        signingCredentials: signingCredentials);
    //    return tokenOptions;
    //}

    //private SigningCredentials GetSigningCredentials()
    //{
    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:key"]));
    //    return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //}
}
