using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.Genre.Response;
using EbookStore.Contract.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Domain.Repository.BookRepo;
public interface IBookRepository
{
    Task<List<BookResponse>> GetAllAsync();
    Task<PagedList<BookResponse>> GetAsync(BookQueryRequest request);
    Task<BookDetailResponse> GetOneAsync(int bookId);
    Task CreateAsync(BookCreateRequest createRequest);
    Task UpdateAsync(BookUpdateRequest updateRequest);
    Task DeleteAsync(int bookId);
}
