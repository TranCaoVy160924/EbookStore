using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Domain.Repository.BookRepo;
using EbookStore.Domain.Repository.SaleRepo;
using Microsoft.AspNetCore.Mvc;

namespace EbookStore.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ISaleRepository _saleRepo;

    public SaleController(
        ISaleRepository saleRepo)
    {
        _saleRepo = saleRepo;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookSaleAsync([FromBody] SaleCreateRequest createRequest, [FromQuery] List<int> bookIds)
    {
        try
        {
            await _saleRepo.CreateBookSaleAsync(createRequest, bookIds);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
