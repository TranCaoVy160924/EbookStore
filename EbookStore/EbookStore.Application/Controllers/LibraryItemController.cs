using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.LibraryItem.Request;
using EbookStore.Contract.ViewModel.WishItem.Request;
using EbookStore.Domain.Repository.LibraryItemRepo;
using EbookStore.Domain.Repository.WishlistRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EbookStore.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryItemController : Controller
{
    private readonly ILibraryRepository _libraryRepo;
    private readonly UserManager<User> _userManager;
    public LibraryItemController(
        ILibraryRepository libraryRepo,
        UserManager<User> userManager)
    {
        _libraryRepo = libraryRepo;
        _userManager = userManager;
    }
    [HttpPost("Search")]
    [Authorize]
    public async Task<IActionResult> GetAsync([FromBody] LibraryItemQueryRequest queryRequest)
    {
        try
        {
            var pagedResult = await _libraryRepo.GetAsync(queryRequest, await GetUserId());

            Response.Headers.Add("X-Pagination", pagedResult.GetMetadata());

            return Ok(pagedResult.Data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
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
