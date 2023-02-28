using EbookStore.Client.Services;
using EbookStore.Contract.ViewModel.Sale.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EbookStore.Client.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<IActionResult> Index()
        {
            var sales = await _saleService.GetSalesAsync();
            var saleResponses = sales.ConvertAll(s => new SaleResponse
            {
                Id = s.Id,
                SalePercentage = s.SalePercentage,
                SaleDate = s.SaleDate
            });
            return View(saleResponses);
        }
    }
}
