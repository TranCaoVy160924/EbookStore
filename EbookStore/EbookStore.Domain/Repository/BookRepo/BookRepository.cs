using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static EbookStore.Domain.Utilities.PaginatorExtension;
using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Domain.Repository.GenreRepo;
using EbookStore.Contract.ViewModel.Book.Response;
using System.Net;

namespace EbookStore.Domain.Repository.BookRepo;

public class BookRepository : IBookRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IGenreRepository _genreRepo;

    public BookRepository(
        EbookStoreDbContext dbContext,
        IMapper mapper,
        IGenreRepository genreRepository)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _genreRepo = genreRepository;
    }

    #region GetAsync
    public async Task<PagedList<BookResponse>> GetAsync(BookQueryRequest request)
    {
        IQueryable<Book> query = _dbContext.Books
            .Include(b => b.Sale)
            .QueryActive()
            .QueryTitle(request.Title)
            .QueryGenres(request.Genres)
            .QueryReleaseDate(request.StartReleaseDate, request.EndReleaseDate)
            .AsQueryable();

        var paginatedResult = await query.PaginateResultAsync(request);
        return paginatedResult.MapResultToResponse<Book, BookResponse>(_mapper);
    }
    #endregion

    #region GetOneAsync
    public async Task<BookDetailResponse> GetOneAsync(int bookId)
    {
        Book book = await _dbContext.Books
            .Include(b => b.Sale)
            .QueryActive()
            .QueryId(bookId)
            .FirstOrDefaultAsync();

        if (book != null)
        {
            return _mapper.Map<BookDetailResponse>(book);
        }
        else
        {
            throw new Exception("Book dont exist");
        }
    }
    #endregion

    #region CreateAsync
    public async Task CreateAsync(BookCreateRequest createRequest)
    {
        Book newBook = _mapper.Map<Book>(createRequest);
        newBook.ReleaseDate = DateTime.Today;
        List<int> requestGenreIds = createRequest.BookGenreIds;
        List<int> genreIds = await _dbContext.Genres.Select(g => g.GenreId).ToListAsync();

        if (await _genreRepo.CheckValidGenresAsync(requestGenreIds))
        {
            try
            {
                _dbContext.Books.Add(newBook);
                await _dbContext.SaveChangesAsync();

                await _genreRepo.AddBookGenreAsync(newBook.BookId, requestGenreIds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        else
        {
            throw new Exception("Genre invalid");
        }
    }
    #endregion

    #region UpdateAsync
    public async Task UpdateAsync(BookUpdateRequest updateRequest)
    {
        Book updatingBook = await _dbContext.Books
            .QueryActive()
            .QueryId(updateRequest.Id)
            .FirstOrDefaultAsync();

        List<int> requestGenreIds = updateRequest.BookGenreIds;
        List<int> genreIds = await _dbContext.Genres.Select(g => g.GenreId).ToListAsync();

        if (updatingBook != null)
        {
            if (await _genreRepo.CheckValidGenresAsync(requestGenreIds))
            {
                try
                {
                    UpdateBook(updatingBook, updateRequest);
                    await _dbContext.SaveChangesAsync();

                    await _genreRepo.UpdateBookGenreAsync(updatingBook.BookId, requestGenreIds);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Genre invalid");
            }
        }
        else
        {
            throw new Exception("Book not exist for updating");
        }
    }

    private static void UpdateBook(Book book, BookUpdateRequest updateRequest)
    {
        book.Title = updateRequest.Title;
        book.Title = updateRequest.Title;
        book.NumberOfPage = updateRequest.NumberOfPage;
        book.Price = updateRequest.Price;
        book.Description = updateRequest.Description;
        book.CoverImage = updateRequest.CoverImage;
        book.PdfLink = updateRequest.PdfLink;
        //book.EpubLink = updateRequest.EpubLink;
    }
    #endregion

    #region DeleteAsync
    public async Task DeleteAsync(int bookId)
    {
        Book book = await _dbContext.Books
            .QueryActive()
            .QueryId(bookId)
            .FirstOrDefaultAsync();

        if (book != null)
        {
            book.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Book not exist");
        }
    }
    #endregion
}
