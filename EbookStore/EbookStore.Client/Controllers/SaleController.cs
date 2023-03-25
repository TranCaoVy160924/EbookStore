namespace EbookStore.Client.Controllers;

using EbookStore.Client.Helper;
using EbookStore.Client.RefitClient;
using EbookStore.Client.ViewModel;
using EbookStore.Contract.ViewModel.Book.Request;
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
        var session = Request.HttpContext.Session;
        if (session.GetString("Name_SaleIndex") == null)
        {
            session.SetString("Name_SaleIndex", string.Empty);
        }

        if (session.GetString("Start_SaleIndex") == null)
        {
            session.SetString("Start_SaleIndex",
                JsonConvert.SerializeObject(DateTime.MinValue));
        }

        if (session.GetString("End_SaleIndex") == null)
        {
            session.SetString("End_SaleIndex",
                JsonConvert.SerializeObject(DateTime.MaxValue));
        }

        if (session.GetString("PageNumber_SaleIndex") == null)
        {
            session.SetString("PageNumber_SaleIndex", "1");
        }

        if (session.GetString("PageSize_SaleIndex") == null)
        {
            session.SetString("PageSize_SaleIndex", "10");
        }

        return View();
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(SaleCreateViewModel viewModel)
    {
        UserManager userManager = new UserManager(User);
        SaleCreateRequest request = new SaleCreateRequest
        {
            Name = viewModel.Name,
            SalePercent = viewModel.SalePercent,
            StartDate = viewModel.StartDate,
            EndDate = viewModel.EndDate,
            BookIds = viewModel.BookIds
        };
        try
        {
            await _saleClient.CreateAsync(request, userManager.GetToken());
            return RedirectToAction("Index", "Sale");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Create", "Sale");
        }
    }
    [HttpPost]
    public IActionResult Filter(string saleName, DateTime saleStart, DateTime saleEnd)
    {
        var session = Request.HttpContext.Session;
        saleName = (saleName != null) ? saleName : "";
        saleStart = (saleStart != null) ? saleStart : DateTime.MinValue;
        saleEnd = (saleEnd != null && saleEnd != DateTime.MinValue) ? saleEnd : DateTime.MaxValue;

        session.SetString("Name_SaleIndex", saleName);
        session.SetString("Start_SaleIndex",
                JsonConvert.SerializeObject(saleStart));
        session.SetString("End_SaleIndex",
                JsonConvert.SerializeObject(saleEnd));
        session.SetString("PageNumber_SaleIndex", "1");

        return RedirectToAction("Index", "Sale");
    }

    [HttpPost]
    public IActionResult ChangePage(string pageNumber)
    {
        var session = Request.HttpContext.Session;
        session.SetString("PageNumber_SaleIndex", pageNumber);
        return RedirectToAction("Index", "Sale");
    }
}
