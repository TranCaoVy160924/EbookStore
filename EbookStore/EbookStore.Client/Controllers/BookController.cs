using Microsoft.AspNetCore.Mvc;

namespace EbookStore.Client.Controllers;
public class BookController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
