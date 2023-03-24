using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Contract.ViewModel.Genre.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.GenreRepo;
public interface IGenreRepository
{
    Task<List<GenreResponse>> GetAsync();
    Task<bool> CheckValidGenresAsync(List<int> bookGenres);
    Task AddBookGenreAsync(int bookId, List<int> genreIds);
    Task UpdateBookGenreAsync(int bookId, List<int> newGenreIds);
    Task<List<GenreResponse>> GetByBookIdAsync(int bookId);
}
