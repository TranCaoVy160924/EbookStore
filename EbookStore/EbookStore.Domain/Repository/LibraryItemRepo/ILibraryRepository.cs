using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Pagination;
using EbookStore.Contract.ViewModel.LibraryItem.Request;
using EbookStore.Contract.ViewModel.LibraryItem.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbookStore.Contract.ViewModel.Book.Response;

namespace EbookStore.Domain.Repository.LibraryItemRepo;
public interface ILibraryRepository
{
    Task<PagedList<LibraryItemResponse>> GetAsync(LibraryItemQueryRequest request, Guid id);

}
