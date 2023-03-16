using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using EbookStore.Client.ViewModel;
using Microsoft.AspNetCore.Mvc;
using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Client.ExternalService.ImageHostService;
using EbookStore.Client.ExternalService.EbookHostService;
using EbookStore.Client.RefitClient;
using EbookStore.Client.Helper;
using Microsoft.AspNetCore.Mvc;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using Microsoft.AspNetCore.Http;
using EbookStore.Client.Helper;

namespace EbookStore.Client.Controllers;
public class BookController : Controller
{
    private readonly IImageHostHelper _imageHelper;
    private readonly IEbookHostHelper _ebookHelper;
    private readonly IBookClient _bookClient;

    public BookController(
        IImageHostHelper imageHelper,
        IEbookHostHelper ebookHelper,
        IBookClient bookClient)
    {
        _imageHelper = imageHelper;
        _ebookHelper = ebookHelper;
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookCreateViewModel viewModel)
    {
        //UserManager userManager = new UserManager(User);
        //BookCreateRequest request = new BookCreateRequest
        //{
        //    Title = viewModel.Title,
        //    NumberOfPage = viewModel.NumberOfPage,
        //    Price = viewModel.Price,
        //    Description = viewModel.Description,
        //    CoverImage = _imageHelper.UploadImage(viewModel.CoverImage),
        //    PdfLink = await _ebookHelper.Upload(viewModel.PdfFile),
        //    EpubLink = await _ebookHelper.Upload(viewModel.PdfFile),
        //    BookGenreIds = viewModel.BookGenreIds,
        //};

        string PdfLink = await _ebookHelper.Upload(viewModel.PdfFile);

        try
        {
            //await _bookClient.CreateAsync(request, userManager.GetToken());
            return RedirectToAction("Index", "Book");
        }
        catch(Exception ex)
        {
            return RedirectToAction("Create", "Book");
        }
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

    [HttpPost]
    public async Task<IActionResult> Delete(int bookId)
    {
        try
        {
            var userManager = new UserManager(User);
            if (userManager.IsLogin())
            {
                await _bookClient.DeleteAsync(bookId, userManager.GetToken());
            }
            return RedirectToAction("Index", "Book");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Book");
        }
    }
}
