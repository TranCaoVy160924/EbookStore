using EbookStore.Client.Helper;
using EbookStore.Client.Models;
using EbookStore.Client.RefitClient;
using EbookStore.Contract.ViewModel.User.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

[Authorize]
public class UserController : Controller
{
    private readonly IUserClient _userClient;

    public UserController(IUserClient userClient)
    {
        _userClient = userClient;
    }

    public IActionResult Index()
    {
        var session = Request.HttpContext.Session;
        if (session.GetString("Username_UserIndex") == null)
        {
            session.SetString("Username_UserIndex", string.Empty);
        }

        if (session.GetString("PageNumber_UserIndex") == null)
        {
            session.SetString("PageNumber_UserIndex", "1");
        }

        if (session.GetString("PageSize_UserIndex") == null)
        {
            session.SetString("PageSize_UserIndex", "10");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ban(string username)
    {
        UserManager userManager = new UserManager(this.User);
        if (ModelState.IsValid)
        {
            if (userManager.IsLogin())
            {
                var Token = userManager.GetToken();
                var userQueryRequest = new UserQueryRequest
                {
                    UserName = username
                };
                var response = await _userClient.BanAsync(userQueryRequest, Token);
                ViewBag.ResponseStatusCode = (int)response.StatusCode; // store the response status code
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
        return View("Index");
    }


    [HttpPost]
    public IActionResult Search(string username)
    {
        var session = Request.HttpContext.Session;
        username = (username != null) ? username : "";
        session.SetString("Username_UserIndex", username);
        return RedirectToAction("Index", "User");
    }

    [HttpPost]
    public IActionResult ChangePage(string pageNumber)
    {
        var session = Request.HttpContext.Session;
        session.SetString("PageNumber_UserIndex", pageNumber);
        return RedirectToAction("Index", "User");
    }
}