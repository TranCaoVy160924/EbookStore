using EbookStore.Contract.ViewModel.Genre.Response;
using EbookStore.Domain.Repository;
using EbookStore.Domain.Repository.GenreRepo;
using Microsoft.AspNetCore.Mvc;

namespace EbookStore.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreRepository _genreRepo;

    public GenreController(
        IGenreRepository genreRepo)
    {
        _genreRepo= genreRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _genreRepo.GetAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByBookIdAsync(int id)
    {
        return Ok(await _genreRepo.GetByBookIdAsync(id));
    }
}
