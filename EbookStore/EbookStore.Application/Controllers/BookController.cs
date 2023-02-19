using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Book.Request;
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

    [HttpPost("Search")]
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        try
        {
            return Ok(await _bookRepo.GetOneAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] BookCreateRequest createRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _bookRepo.CreateAsync(createRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPatch]
    [Authorize]
    public async Task<IActionResult> UpdateAsync([FromBody] BookUpdateRequest updateRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _bookRepo.UpdateAsync(updateRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            await _bookRepo.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}
