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

namespace EbookStore.Domain.Repository.WishlistRepo;
public class WishlistRepository : IWishlistRepository
{
    private readonly EbookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public WishlistRepository(
        EbookStoreDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task AddBookToWishlistAsync(int bookId, string username)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == username);

        if (user == null)
        {
            throw new ApplicationException($"Unable to find user with username: {username}");
        }

        var book = await _dbContext.Books.SingleOrDefaultAsync(b => b.BookId == bookId);

        if (book == null)
        {
            throw new ApplicationException($"Unable to find book with id: {bookId}");
        }

        var wishItem = new WishItem
        {
            UserId = user.Id,
            BookId = book.BookId,
            IsActive = true
        };

        _dbContext.WishItems.Add(wishItem);
        await _dbContext.SaveChangesAsync();
    }

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
}
