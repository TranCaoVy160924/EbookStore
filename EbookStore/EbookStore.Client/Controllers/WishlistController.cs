using EbookStore.Client.Helper;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;

namespace EbookStore.Client.Controllers;
public class WishlistController : Controller
{
    private readonly IWishlistClient _wishlistClient;

    public WishlistController(IWishlistClient wishlistClient)
    {
        _wishlistClient = wishlistClient;
    }

    [HttpPost]
    public async Task<IActionResult> AddToWishlist(int bookId)
    {
        try
        {
            UserManager userManager = new UserManager(User);
            if (userManager.IsLogin())
            {
                await _wishlistClient.AddBookToWishlistAsync(bookId, userManager.GetToken());
                return RedirectToAction("Index", controllerName: "Home");
            }
            return RedirectToAction("Login", "Auth");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", controllerName: "Home");
        }

    }
}
