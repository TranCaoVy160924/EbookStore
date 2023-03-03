namespace EbookStore.Client.Controllers;

using EbookStore.Client.Helper;
using EbookStore.Client.RefitClient;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Contract.ViewModel.Sale.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Authorize]
public class SaleController : Controller
{
    private readonly ISaleClient _saleClient;
    public SaleController(ISaleClient saleClient)
    {
        _saleClient = saleClient;
    }

    [HttpPost]
    public async Task<IActionResult> Update(SaleExtendRequest saleExtendRequest)
    {
        UserManager userManager = new UserManager(this.User);
        if (ModelState.IsValid)
        {
            if (userManager.IsLogin())
            {
                var token = userManager.GetToken();
                saleExtendRequest = new SaleExtendRequest
                {
                    SaleId = saleExtendRequest.SaleId,
                    NewEndDate = saleExtendRequest.NewEndDate
                };
                await _saleClient.ExtendSaleAsync(saleExtendRequest, token);
                return RedirectToAction("Index");
            }
        }
        return View(saleExtendRequest);
    }

    public IActionResult Index()
    {
        return View();
    }
}
