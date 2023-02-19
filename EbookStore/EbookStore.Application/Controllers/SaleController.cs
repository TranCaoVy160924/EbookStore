using EbookStore.Contract.ViewModel.Sale.Request;
using EbookStore.Domain.Repository.SaleRepo;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        try
        {
            return Ok(await _saleRepo.GetOneAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookSaleAsync([FromBody] SaleCreateRequest createRequest)
    {
        try
        {
            await _saleRepo.CreateBookSaleAsync(createRequest);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    [HttpPatch]
    [Authorize]
    public async Task<IActionResult> UpdateExtendSaleAsync([FromBody] SaleExtendRequest updateSaleExtendRequest)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            await _saleRepo.UpdateExtendSaleAsync(updateSaleExtendRequest);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }
}
