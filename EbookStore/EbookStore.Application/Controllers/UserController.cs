using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Domain.Repository;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using EbookStore.Contract.ViewModel.User.UserRegisterResponse;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;
using EbookStore.Data.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static EbookStore.Application.ValidateHelper;

namespace EbookStore.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepo;

    public UserController(
        UserManager<User> userManager,
        IConfiguration config,
        IUserRepository userRepo)
    {
        _userManager = userManager;
        _config = config;
        _userRepo = userRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        if (!Validate(request))
        {
            return BadRequest("Invalid Request");
        }

        if (await _userRepo.IsDuplicateUserNameAsync(request.UserName))
        {
            return BadRequest("User already exist");
        }

        try
        {
            UserRegisterResponse newUser = await _userRepo.CreateAsync(request);
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);

        }
    }

    [HttpPost("auth/token/")]
    public async Task<IActionResult> Authenticate([FromBody] UserLoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = await _userRepo.FindUserFromLoginRequestAsync(request);
            var role = await _userRepo.GetUserRoleAsync(user);
            return Ok(CreateToken(user, request.UserName, role));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

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
