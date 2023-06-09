﻿using EbookStore.Client.ExternalService.EbookHostService;
using EbookStore.Client.ExternalService.ImageHostService;
using EbookStore.Client.Helper;
using EbookStore.Client.RefitClient;
using EbookStore.Client.ViewModel;
using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Contract.ViewModel.Book.Response;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Update(int id)
    {
        var session = Request.HttpContext.Session;
        session.SetString("chosen_id", id.ToString());
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
            //EpubLink = await _ebookHelper.Upload(viewModel.PdfFile),
            BookGenreIds = viewModel.BookGenreIds,
        };

        try
        {
            await _bookClient.CreateAsync(request, userManager.GetToken());
            return RedirectToAction("Index", "Book");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Create", "Book");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Update(BookUpdateViewModel viewModel, string description)
    {
        UserManager userManager = new UserManager(User);

        try
        {
            if(String.IsNullOrEmpty(description))
            {
                TempData["DescriptionError"] = "Please enter book description";
                throw new Exception();
            }

            BookUpdateRequest request = new BookUpdateRequest
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                NumberOfPage = viewModel.NumberOfPage,
                Price = viewModel.Price,
                Description = description,
                CoverImage = viewModel.CoverImage == null ? viewModel.StringCoverImage : _imageHelper.UploadImage(viewModel.CoverImage),
                PdfLink = viewModel.PdfFile == null ? viewModel.StringPdfFile : await _ebookHelper.Upload(viewModel.PdfFile),
                BookGenreIds = viewModel.BookGenreIds
            };

            await _bookClient.UpdateAsync(request, userManager.GetToken());
            return RedirectToAction("Index", "Book");
        }
        catch (Exception)
        {
            return RedirectToAction("Update", "Book");
        }
    }

    [HttpPost]
    public IActionResult Search(string title, DateTime start, DateTime end, List<int> genres)
    {
        var session = Request.HttpContext.Session;
        title ??= String.Empty;
        start = start == DateTime.MinValue ? DateTime.MinValue : start;
        end = end == DateTime.MinValue ? DateTime.MaxValue : end;
        genres ??= new List<int>();

        string genresString = String.Empty;
        if (genres.Count > 0)
        {
            foreach (var genre in genres) { genresString += genre + " "; }
        }

        session.SetString("Title_BookIndex", title);
        session.SetString("Genres_BookIndex", genresString);
        session.SetString("StartReleaseDate_BookIndex", start.ToString());
        session.SetString("EndReleaseDate_BookIndex", end.ToString());
        session.SetString("PageNumber_BookIndex", "1");

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
