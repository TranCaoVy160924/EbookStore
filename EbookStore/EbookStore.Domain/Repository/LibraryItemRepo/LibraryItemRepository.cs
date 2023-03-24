using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Data.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.LibraryItemRepo;
public class LibraryItemRepository : ILibraryItemRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public LibraryItemRepository(
       EbookStoreDbContext dbContext,
       IMapper mapper,
       UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userManager = userManager;
    }

    #region addToLibraryAsync
    public async Task AddBookToLibrarylistAsync(int bookId, Guid userId)
    {
        var checkExsited = await _dbContext.LibraryItems.SingleOrDefaultAsync(ci => ci.UserId == userId && ci.BookId == bookId);
        if (checkExsited != null)
        {
            throw new ApplicationException($"This book {bookId} is already in library.");
        }
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            throw new ApplicationException($"Unable to find user with username: {userId}");
        }

        var book = await _dbContext.Books.SingleOrDefaultAsync(b => b.BookId == bookId);

        if (book == null)
        {
            throw new ApplicationException($"Unable to find book with id: {bookId}");
        }

        var librayItem = new LibraryItem
        {
            UserId = user.Id,
            User = user,
            BookId = book.BookId,
            Book = book
        };

        _dbContext.LibraryItems.Add(librayItem);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
}
