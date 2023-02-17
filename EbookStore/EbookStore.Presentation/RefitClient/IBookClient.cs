using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Presentation.RefitClient;

[Headers("Content-Type: application/json")]
public interface IBookClient
{
    [Get("/Book")]
    Task<ApiResponse<List<BookResponse>>> GetResponseAsync([Body] BookQueryRequest queryRequest,
        [Header("Authorization")] string jwtToken);
}
