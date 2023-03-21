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

    public IActionResult Index()
    {
        return View();
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

    [HttpPost]
    public async Task<IActionResult> RemoveItems(int bookId)
    {
        try
        {
            var userManager = new UserManager(User);
            if (userManager.IsLogin())
            {
                await _wishlistClient.RemoveItemsAsync(bookId, userManager.GetToken());
            }
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
    }
}
