using EbookStore.Client.Models;
using EbookStore.Client.RefitClient;
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
    public IActionResult Search(string username)
    {
        var session = Request.HttpContext.Session;
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