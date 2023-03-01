using EbookStore.Client.Models;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class UserController : Controller
{
    private readonly IUserClient _userClient;

    public UserController(IUserClient userClient)
    {
        _userClient = userClient;
    }
    public async Task<IActionResult> Index()
    {
        var sales = await _userClient.GetResponseAsync();
        var saleResponses = sales.ConvertAll(s => new SaleResponse
        {
            Id = s.Id,
            SalePercentage = s.SalePercentage,
            SaleDate = s.SaleDate
        });
        return View(saleResponses);
    }
}
