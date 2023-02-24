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
using EbookStore.Contract.ViewModel.User.Request;

namespace EbookStore.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepo;

    public UserController(
        IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
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
            return Ok(await _userRepo.CreateTokenAsync(user));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("Search")]
    public async Task<IActionResult> GetUsersAsync([FromBody] UserQueryRequest queryRequest)
    {
        try
        {
            var pagedResult = await _userRepo.GetUsersAsync(queryRequest);

            Response.Headers.Add("X-Pagination", pagedResult.GetMetadata());

            return Ok(pagedResult.Data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
