using EbookStore.Client.Helper;
using EbookStore.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EbookStore.Client.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        UserManager userManager = new UserManager(User);
        if (userManager.IsLogin() && userManager.GetUserRole().Equals("Admin"))
        {
            return RedirectToAction("Index", "Book");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Shop()
    {
        var session = Request.HttpContext.Session;
        var titleSearch = TempData["TitleSearch"];
        if (titleSearch == null)
        {
            titleSearch = "";
        }

        if (session.GetString("Start_HomeShop") == null)
        {
            session.SetString("Start_HomeShop",
                JsonConvert.SerializeObject(DateTime.MinValue));
        }

        if (session.GetString("End_HomeShop") == null)
        {
            session.SetString("End_HomeShop",
                JsonConvert.SerializeObject(DateTime.MaxValue));
        }

        if (session.GetString("PageNumber_HomeShop") == null)
        {
            session.SetString("PageNumber_HomeShop", "1");
        }

        if (session.GetString("PageSize_HomeShop") == null)
        {
            session.SetString("PageSize_HomeShop", "12");
        }

        ViewData["TitleSearch"] = titleSearch;
        return View();
    }

    public IActionResult SearchTitle(string title)
    {
        var session = Request.HttpContext.Session;
        TempData["TitleSearch"] = title;
        session.SetString("PageNumber_HomeShop", "1");
        return RedirectToAction("Shop", "Home");
    }

    public IActionResult SearchGenre(int genreId)
    {
        var session = Request.HttpContext.Session;
        session.SetString("Genre", genreId.ToString());
        session.SetString("PageNumber_HomeShop", "1");
        return RedirectToAction("Shop", "Home");
    }

    public IActionResult DateFilter(DateTime startDate, DateTime endDate)
    {
        var session = Request.HttpContext.Session;
        startDate = (startDate != null) ? startDate : DateTime.MinValue;
        endDate = (endDate != null && endDate != DateTime.MinValue) ? endDate  : DateTime.MaxValue;

        session.SetString("Start_HomeShop",
                JsonConvert.SerializeObject(startDate));
        session.SetString("End_HomeShop",
                JsonConvert.SerializeObject(endDate));
        session.SetString("PageNumber_HomeShop", "1");

        return RedirectToAction("Shop", "Home");
    }

    [HttpPost]
    public IActionResult ChangePage(string pageNumber)
    {
        var session = Request.HttpContext.Session;
        session.SetString("PageNumber_HomeShop", pageNumber);
        return RedirectToAction("Shop", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
