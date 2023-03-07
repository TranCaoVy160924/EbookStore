using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.CartItem.Request;
using EbookStore.Domain.Repository.CartlistRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EbookStore.Application.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CartlistController : ControllerBase
{
    private readonly ICartlistRepository _cartlistRepo;
    private readonly UserManager<User> _userManager;

    public CartlistController(
        ICartlistRepository cartlistRepo,
        UserManager<User> userManager)
    {
        _cartlistRepo = cartlistRepo;
        _userManager = userManager;
    }

    [HttpPost("Search")]
    [Authorize]
    public async Task<IActionResult> GetAsync([FromBody] CartItemQueryRequest queryRequest)
    {
        try
        {
            var pagedResult = await _cartlistRepo.GetAsync(queryRequest, GetUserId());

            Response.Headers.Add("X-Pagination", pagedResult.GetMetadata());

            return Ok(pagedResult.Data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{bookId}")]
    [Authorize]
    public async Task<IActionResult> AddBookToCartlist(int bookId)
    {
        try
        {
            var userId = GetUserId();

            await _cartlistRepo.AddBookToCartlistAsync(bookId, await userId);
            return Ok();
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        }
    }

    private async Task<Guid> GetUserId()
    {
        var claims = User.Claims.ToList();

        var userName = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        User user = await _userManager.FindByNameAsync(userName);

        return user.Id;
    }
}
