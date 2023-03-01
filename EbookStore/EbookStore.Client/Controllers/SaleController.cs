namespace EbookStore.Client.Controllers;

using EbookStore.Client.RefitClient;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Contract.ViewModel.Sale.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;

public class SaleController: Controller
{
    private readonly ISaleClient _saleClient;
    public SaleController(ISaleClient userClient)
    {
        _saleClient = userClient;
    }
    public IActionResult Index() {

        return View();
    }

}
