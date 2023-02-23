using EbookStore.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.WishlistRepo;
public interface IWishlistRepository
{
    Task<List<User>> GetWishersAsync(int bookId);
    void SendSaleNotifyEmail(List<string> wishers, string bookName);
    Task AddBookToWishlistAsync(int bookId, Guid userId);
}
