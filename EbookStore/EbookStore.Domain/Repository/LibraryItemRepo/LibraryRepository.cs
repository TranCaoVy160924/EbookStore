using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.CartItem.Request;
using EbookStore.Contract.ViewModel.LibraryItem.Request;
using EbookStore.Contract.ViewModel.LibraryItem.Response;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Data.EF;
using EbookStore.Domain.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.LibraryItemRepo;
public class LibraryRepository : ILibraryRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public LibraryRepository(
       EbookStoreDbContext dbContext,
       IMapper mapper,
       UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userManager = userManager;
    }

    #region GetAsync
    public async Task<PagedList<LibraryItemResponse>> GetAsync(LibraryItemQueryRequest request, Guid id)
    {
        IQueryable<Book> query = _dbContext.LibraryItems
            .Where(l => l.UserId == id)
            .Include(l => l.Book)
            .ThenInclude(b => b.Sale)
            .Select(l => l.Book)
            .OrderByDescending(b => b.ReleaseDate)
            .AsQueryable();

        var paginatedResult = await query.PaginateResultAsync(request);

        return paginatedResult.MapResultToResponse<Book, LibraryItemResponse>(_mapper);
    }
    #endregion
}
