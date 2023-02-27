using EbookStore.Client.Helper;
using EbookStore.Client.RefitClient;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.User.UserLoginRequest;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Security.Claims;
using EbookStore.Contract.ViewModel.User.UserRegsiterRequest;

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

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Login", "Auth");
        }

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
                return RedirectToAction("Index", "Book");
            }
        }
        catch
        {
            TempData["LoginErrorMessage"] = "Password or Username is invalid";
            return RedirectToAction("Login", "Auth");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Register", "Auth");
        }

        try
        {
            await _userClient.RegisterAsync(request);

            return RedirectToAction("Login", "Auth");
        }
        catch (Exception ex)
        {
            TempData["RegisterErrorMessage"] = "Register unccessfully";
            return RedirectToAction("Register", "Auth");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
