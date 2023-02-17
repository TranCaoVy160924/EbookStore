using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Domain.Repository;
using EbookStore.Domain.Repository.BookRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace EbookStore.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepo;

    public BookController(
        IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    //[Authorize]
    [HttpGet()]
    public async Task<IActionResult> GetAsync([FromBody] BookQueryRequest queryRequest)
    {
        try
        {
            var pagedResult = await _bookRepo.GetAsync(queryRequest);

            Response.Headers.Add("X-Pagination", pagedResult.GetMetadata());

            return Ok(pagedResult.Data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
