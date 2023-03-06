using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;

namespace EbookStore.Client.Controllers;
public class BookController : Controller
{

    private readonly IBookClient _bookClient;


    public BookController(IBookClient bookClient)
    {
        _bookClient = bookClient;
    }

    public IActionResult Index()
    {
        var session = Request.HttpContext.Session;
        if (session.GetString("Title_BookIndex") == null)
        {
            session.SetString("Title_BookIndex", string.Empty);
        }

        if (session.GetString("Genres_BookIndex") == null)
        {
            session.SetString("Genres_BookIndex", string.Empty);
        }

        if (session.GetString("StartReleaseDate_BookIndex") == null)
        {
            session.SetString("StartReleaseDate_BookIndex", DateTime.MinValue.ToString());
        }

        if (session.GetString("EndReleaseDate_BookIndex") == null)
        {
            session.SetString("EndReleaseDate_BookIndex", DateTime.MaxValue.ToString());
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

    [HttpPost]
    public IActionResult Search(BookQueryRequest request)
    {
        var session = Request.HttpContext.Session;
        if (request!=null)
        {
            request.Title = request.Title!=null ? request.Title : String.Empty;
            request.Genres = request.Genres!=null ? request.Genres : new List<int>();

            string genresString = String.Empty;
            if (request.Genres.Count==0)
            {
                foreach (var genres in request.Genres) { genresString += genres + " "; }
            }

            session.SetString("Title_BookIndex", request.Title);
            session.SetString("Genres_BookIndex", genresString);
            session.SetString("StartReleaseDate_BookIndex", request.StartReleaseDate.ToString());
            session.SetString("EndReleaseDate_BookIndex", request.EndReleaseDate.ToString());
        }

        return RedirectToAction("Index", "Book");
    }

    [HttpPost]
    public IActionResult ChangePage(string pageNumber)
    {
        var session = Request.HttpContext.Session;
        session.SetString("PageNumber_BookIndex", pageNumber);
        return RedirectToAction("Index", "Book");
    }
}
