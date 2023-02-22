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
        var username = User.GetUsername();
        await _wishlistRepo.AddBookToWishlistAsync(bookId, username);
        return Ok();
    }
}
