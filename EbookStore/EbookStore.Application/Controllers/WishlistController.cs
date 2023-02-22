using EbookStore.Application.Helpers;
using EbookStore.Domain.Repository.WishlistRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EbookStore.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WishlistController : ControllerBase
{
    private readonly IWishlistRepository _wishlistRepo;

    public WishlistController(IWishlistRepository wishlistRepo)
    {
        _wishlistRepo = wishlistRepo;
    }

    [HttpPost("{bookId}")]
    [Authorize]
    public async Task<IActionResult> AddBookToWishlist(int bookId)
    {
        try
        {
            var username = User.GetUsername();
            await _wishlistRepo.AddBookToWishlistAsync(bookId, username);
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
}
