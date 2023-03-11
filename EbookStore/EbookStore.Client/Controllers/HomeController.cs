﻿using EbookStore.Client.Helper;
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

        ViewData["TitleSearch"] = titleSearch;
        return View();
    }

    public IActionResult SearchTitle(string title)
    {
        TempData["TitleSearch"] = title;
        return RedirectToAction("Shop", "Home");
    }

    public IActionResult SearchGenre(int genreId)
    {
        var session = Request.HttpContext.Session;
        session.SetString("Genre", genreId.ToString());
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

        return RedirectToAction("Shop", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
