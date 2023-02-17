using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Genre.Response;
using EbookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.GenreRepo;
public class GenreRepository : IGenreRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GenreRepository(EbookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<GenreResponse>> GetAsync()
    {
        List<Genre> genres = await _dbContext.Genres.ToListAsync();
        return _mapper.Map<List<GenreResponse>>(genres);
    }

    public async Task<bool> CheckValidGenresAsync(List<int> bookGenres)
    {
        bool validGenres = true;
        List<int> genreIds = await _dbContext.Genres.Select(g => g.GenreId).ToListAsync();
        foreach (int genreId in bookGenres)
        {
            if (!genreIds.Contains(genreId))
            {
                validGenres = false;
            }
        }
        return validGenres;
    }

    public async Task AddBookGenreAsync(int bookId, List<int> genreIds)
    {
        foreach (int genreId in genreIds)
        {
            _dbContext.BookGenres.Add(new BookGenre
            {
                BookId = bookId,
                GenreId = genreId
            });
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBookGenreAsync(int bookId, List<int> newGenreIds)
    {
        await ClearBookGenre(bookId);
        await AddBookGenreAsync(bookId, newGenreIds);
    }

    private async Task ClearBookGenre(int bookId)
    {
        List<BookGenre> currentBookGenres = await _dbContext.BookGenres
            .Where(bg => bg.BookId == bookId)
            .ToListAsync();

        foreach (BookGenre bookGenre in currentBookGenres)
        {
            _dbContext.BookGenres.Remove(bookGenre);
        }
        await _dbContext.SaveChangesAsync();
    }
}
