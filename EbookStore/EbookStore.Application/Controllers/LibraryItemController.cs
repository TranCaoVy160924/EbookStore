using EbookStore.Contract.Model;
using EbookStore.Domain.Repository.LibraryItemRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EbookStore.Application.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LibraryItemController : ControllerBase
{
    private readonly ILibraryItemRepository _libraryItemRepo;
    private readonly UserManager<User> _userManager;

    public LibraryItemController(
        ILibraryItemRepository libraryItemRepo,
        UserManager<User> userManager)
    {
        _libraryItemRepo = libraryItemRepo;
        _userManager = userManager;
    }

    [HttpPost("{bookId}")]
    [Authorize]
    public async Task<IActionResult> AddBookToCartlist(int bookId)
    {
        try
        {
            var userId = await GetUserId();

            await _libraryItemRepo.AddBookToLibrarylistAsync(bookId, userId);
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
