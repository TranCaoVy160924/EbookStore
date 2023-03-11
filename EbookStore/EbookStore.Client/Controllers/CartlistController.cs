using EbookStore.Client.Helper;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EbookStore.Client.Controllers;
public class CartlistController : Controller
{
    private readonly ICartlistClient _cartistClient;

    public CartlistController(ICartlistClient cartlistClient)
    {
        _cartistClient = cartlistClient;
    }

    public IActionResult Index()
    {
        UserManager userManager = new UserManager(User);
        if (userManager.IsLogin())
        {
            return View();
        }
        return RedirectToAction("Login", "Auth");
    }

    [HttpPost]
    public async Task<IActionResult> AddToCartlist(int cartAddBookId)
    {
        try
        {
            UserManager userManager = new UserManager(User);
            if (userManager.IsLogin())
            {
                await _cartistClient.AddBookToCartlistAsync(cartAddBookId, userManager.GetToken());
                return RedirectToAction("Index", controllerName: "Home");
            }
            return RedirectToAction("Login", "Auth");
        }
        catch(Exception ex)
        {
            return RedirectToAction("Index", controllerName: "Home");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int bookId)
    {
        UserManager userManager = new UserManager(User);
        await _cartistClient.DeleteBookAsync(bookId, userManager.GetToken());
        return RedirectToAction("Index", "Cartlist");
    }
}
