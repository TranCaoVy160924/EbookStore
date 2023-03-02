using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using EbookStore.Client.ViewModel;
using Microsoft.AspNetCore.Mvc;
using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Client.ExternalService.ImageHostService;
using EbookStore.Client.ExternalService.EbookHostService;
using EbookStore.Client.RefitClient;
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
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookCreateViewModel viewModel)
    {
        UserManager userManager = new UserManager(User);
        BookCreateRequest request = new BookCreateRequest
        {
            Title = viewModel.Title,
            NumberOfPage = viewModel.NumberOfPage,
            Price = viewModel.Price,
            Description = viewModel.Description,
            CoverImage = _imageHelper.UploadImage(viewModel.CoverImage),
            PdfLink = await _ebookHelper.Upload(viewModel.PdfFile),
            EpubLink = await _ebookHelper.Upload(viewModel.PdfFile),
            BookGenreIds = viewModel.BookGenreIds,
        };

        try
        {
            await _bookClient.CreateAsync(request, userManager.GetToken());
        }
        catch(Exception ex)
        {
            return RedirectToAction("Create", "Book");
        }

        return RedirectToAction("Index", "Book");
    }
}
