using EbookStore.Client.ExternalService.EbookHostService;
using EbookStore.Client.ExternalService.ImageHostService;
using EbookStore.Contract.ViewModel.LibraryItem.Request;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EbookStore.Client.Controllers;

public class LibraryController : Controller
{
    private readonly IImageHostHelper _imageHelper;
    private readonly IEbookHostHelper _ebookHelper;
    private readonly ILibraryClient _libraryClient;
    public LibraryController(
        IImageHostHelper imageHelper,
        IEbookHostHelper ebookHelper,
        ILibraryClient libraryClient)
    {
        _imageHelper = imageHelper;
        _ebookHelper = ebookHelper;
        _libraryClient = libraryClient;

    }
    public IActionResult Index()
    {
        var session = Request.HttpContext.Session;
        if (session.GetString("Title_BookIndex") == null)
        {
            session.SetString("Title_BookIndex", string.Empty);
        }

        if (session.GetString("PageNumber_BookIndex") == null)
        {
            session.SetString("PageNumber_BookIndex", "1");
        }

        if (session.GetString("PageSize_BookIndex") == null)
        {
            session.SetString("PageSize_BookIndex", "10");
        }

        return View();
    }

    public IActionResult Search(LibraryItemQueryRequest request)
    {
        var session = Request.HttpContext.Session;
        if (request != null)
        {
            request.Title = request.Title != null ? request.Title : String.Empty;
            session.SetString("Title_BookIndex", request.Title);
        }

        return RedirectToAction("Index", "Library");
    }

    public IActionResult ChangePage(string pageNumber)
    {
        var session = Request.HttpContext.Session;
        session.SetString("PageNumber_BookIndex", pageNumber);
        return RedirectToAction("Index", "Library");
    }
}
