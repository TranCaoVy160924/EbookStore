using EbookStore.Client.Helper;
using EbookStore.Client.Models;
using Microsoft.AspNetCore.Mvc;
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
