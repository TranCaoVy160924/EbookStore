using EbookStore.Contract.Model;
using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.WishItem.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.WishlistRepo;
public interface IWishlistRepository
{
    Task<List<User>> GetWishersAsync(int bookId);
    void SendSaleNotifyEmail(List<string> wishers, string bookName);
    Task AddBookToWishlistAsync(int bookId, Guid userId);
    Task<PagedList<BookResponse>> GetAsync(WishItemQueryRequest request, Guid id);
    Task<int> GetCountAsync(Guid userId);
    Task RemoveItemsAsync(int bookId, Guid userId);
    Task AddItemToCartAsync(int bookId, Guid userId);
}
