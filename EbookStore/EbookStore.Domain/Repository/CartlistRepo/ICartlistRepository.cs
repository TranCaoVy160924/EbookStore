using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.CartItem.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.CartlistRepo;
public interface ICartlistRepository
{
    Task AddBookToCartlistAsync(int bookId, Guid userId);
    Task<PagedList<BookResponse>> GetAsync(CartItemQueryRequest request, Guid id);
    Task<int> GetCountAsync(Guid userId);
    Task DeleteAsync(int bookId, Guid userId);
}
