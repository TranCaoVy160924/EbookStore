using EbookStore.Client.Helper;
using EbookStore.Client.RefitClient;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Security.Claims;

namespace EbookStore.Client.Controllers;
public class AuthController : Controller
{
    private readonly IUserClient _userClient;

    public AuthController(IUserClient userClient)
    {
        _userClient = userClient;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        try
        {
            string token = await _userClient.AuthenticateAsync(request);

            // Http login
            JwtManager jwtManager = new JwtManager(token);
            var claimsPrinciple = jwtManager.GetPriciples();
            await HttpContext.SignInAsync(claimsPrinciple);

            if (jwtManager.GetUserRole().Equals("User"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                throw new Exception("Admin");
            }
        }
        catch
        {
            TempData["LoginErrorMessage"] = "Password or Username is invalid";
            return RedirectToAction("Login", "Auth");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
