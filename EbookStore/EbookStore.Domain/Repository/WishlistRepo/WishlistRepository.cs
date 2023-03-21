using AutoMapper;
using EbookStore.Contract.Model;
using EbookStore.Data.EF;
using EbookStore.Domain.Repository.BookRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.WishItem.Request;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Domain.Utilities;
using EbookStore.Domain.Repository.GenreRepo;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using System.Net.Http;
using EbookStore.Domain.Repository.CartlistRepo;

namespace EbookStore.Domain.Repository.WishlistRepo;
public class WishlistRepository : IWishlistRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public WishlistRepository(
        EbookStoreDbContext dbContext,
        IMapper mapper,
        UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userManager = userManager;
    }

    #region addToWishlistAsync
    public async Task AddBookToWishlistAsync(int bookId, Guid userid)
    {
        var existingWishItem = await _dbContext.WishItems.SingleOrDefaultAsync(wi => wi.UserId == userid && wi.BookId == bookId);
        if (existingWishItem != null)
        {
            throw new ApplicationException($"This book {bookId} is already in the wishlist.");
        }
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == userid);

        if (user == null)
        {
            throw new ApplicationException($"Unable to find user with username: {userid}");
        }

        var book = await _dbContext.Books.SingleOrDefaultAsync(b => b.BookId == bookId);

        if (book == null)
        {
            throw new ApplicationException($"Unable to find book with id: {bookId}");
        }

        var wishItem = new WishItem
        {
            UserId = user.Id,
            User = user,
            BookId = book.BookId,
            Book = book,
            IsActive = true
        };

        _dbContext.WishItems.Add(wishItem);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region GetWisherAsync
    public async Task<List<User>> GetWishersAsync(int bookId)
    {
        var wishedBook = await _dbContext.Books.QueryId(bookId).FirstOrDefaultAsync();
        if (wishedBook == null)
        {
            throw new Exception("Book not exist");
        }

        return wishedBook.WishItems.Select(wi => wi.User).ToList();
    }
    #endregion

    #region SendSaleNotifyEmail
    public void SendSaleNotifyEmail(List<string> wishers, string bookName)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("vytcse160924@fpt.edu.vn", "wnwdgndadurwcwzg"),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("vytcse160924@fpt.edu.vn"),
            Subject = "Wished book on sale",
            Body = $"<h1>{bookName} is on sale</h1>",
            IsBodyHtml = true,
        };
        foreach (string whisherEmail in wishers)
        {
            mailMessage.To.Add(whisherEmail);
        }

        smtpClient.Send(mailMessage);
    }
    #endregion

    #region GetAsync
    public async Task<PagedList<BookResponse>> GetAsync(WishItemQueryRequest request, Guid id)
    {
        IQueryable<Book> query = _dbContext.Books
            .Include(b => b.Sale)
            .QueryActive()
            .QueryTitle(request.Title)
            .QueryGenres(request.Genres)
            .QueryReleaseDate(request.StartReleaseDate, request.EndReleaseDate)
            .QueryCurrentWishItem(_dbContext.WishItems, id)
            .AsQueryable();

        var paginatedResult = await query.PaginateResultAsync(request);
        return paginatedResult.MapResultToResponse<Book, BookResponse>(_mapper);
    }
    #endregion

    #region GetCountAsync
    public async Task<int> GetCountAsync(Guid userId)
    {
        int Count = _dbContext.WishItems
            .Where(c => c.UserId == userId)
            .Where(c => c.IsActive)
            .Count();
        return Count;
    }
    #endregion

    #region RemoveItemsAsync
    public async Task RemoveItemsAsync(int bookId, Guid userId)
    {
        WishItem wishItem = await _dbContext.WishItems
            .Where(x => x.IsActive == true)
            .Where(x => x.BookId == bookId)
            .Where(x=>x.UserId== userId)
            .FirstOrDefaultAsync();
        if (wishItem != null)
        {
            wishItem.IsActive = false; 
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Book not exist");
        }
    }
    #endregion

}
