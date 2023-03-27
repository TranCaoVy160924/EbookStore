using EbookStore.Client.Helper;
using EbookStore.Client.Models;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EbookStore.Client.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWishlistClient _wishlistClient;

    public HomeController(ILogger<HomeController> logger, IWishlistClient wishlistClient)
    {
        _logger = logger;
        _wishlistClient = wishlistClient;
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

    public IActionResult SearchGenre(int genreId, string titleSearch)
    {
        TempData["TitleSearch"] = titleSearch;
        var session = Request.HttpContext.Session;
        session.SetString("Genre", genreId.ToString());
        session.SetString("PageNumber_HomeShop", "1");
        return RedirectToAction("Shop", "Home");
    }

    public IActionResult DateFilter(DateTime startDate, DateTime endDate, string titleSearch)
    {
        TempData["TitleSearch"] = titleSearch;
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
    public async Task<IActionResult> AddToWishlistFromShop(int bookId, string titleSearch)
    {
        TempData["TitleSearch"] = titleSearch;
        try
        {
            UserManager userManager = new UserManager(User);
            if (userManager.IsLogin())
            {
                await _wishlistClient.AddBookToWishlistAsync(bookId, userManager.GetToken());
                return RedirectToAction("Shop", controllerName: "Home");
            }
            return RedirectToAction("Login", "Auth");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Shop", controllerName: "Home");
        }
    }

    public IActionResult Detail(int id)
    {
        var session = Request.HttpContext.Session;
        session.SetString("chosen_id", id.ToString());
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddItemToCartFromShop(int bookId, string titleSearch)
    {
        TempData["TitleSearch"] = titleSearch;
        try
        {
            var userManager = new UserManager(this.User);
            if (userManager.IsLogin())
            {
                await _wishlistClient.AddItemtoCartAsync(bookId, userManager.GetToken());
                await _wishlistClient.RemoveItemsAsync(bookId, userManager.GetToken());
                return RedirectToAction("Shop", "Home");
            }
            return RedirectToAction("Login", "Auth");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Shop", "Home");
        }
    }

    [HttpPost]
    public IActionResult ChangePage(string pageNumber, string titleSearch)
    {
        TempData["TitleSearch"] = titleSearch;
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
