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

namespace EbookStore.Domain.Repository.BookRepo;

public class BookRepository : IBookRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookRepository(EbookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PagedList<BookResponse>> GetAsync(BookQueryRequest request)
    {
        IQueryable<Book> query = _dbContext.Books
            .Include(b => b.Sale)
            .QueryTitle(request.Title)
            .QueryGenres(request.Genres)
            .QueryReleaseDate(request.StartReleaseDate, request.EndReleaseDate)
            .AsQueryable();

        var paginatedResult = await query.PaginateResultAsync(request);
        return paginatedResult.MapResultToResponse<Book, BookResponse>(_mapper);
    }
}
