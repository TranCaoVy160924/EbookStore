using EbookStore.Client.Helper;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;

namespace EbookStore.Client.Controllers;
public class LibraryItemController : Controller
{
    private readonly ILibraryItemClient _libraryItemClient;

    public LibraryItemController(ILibraryItemClient libraryItemClient)
    {
        _libraryItemClient = libraryItemClient;
    }


    [HttpPost]
    public async Task<IActionResult> AddToLibrary(int cartAddBookId)
    {
        try
        {
            UserManager userManager = new UserManager(User);
            if (userManager.IsLogin())
            {
                await _libraryItemClient.AddBookToLibraryAsync(cartAddBookId, userManager.GetToken());
                return RedirectToAction("Index", "Cartlist");
            }
            return RedirectToAction("Index", "Cartlist");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Cartlist");
        }
    }
}
