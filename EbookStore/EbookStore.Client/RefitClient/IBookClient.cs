using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Book.Request;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStore.Client.RefitClient;

[Headers("Content-Type: application/json")]
public interface IBookClient
{
    [Get("/Book")]
    Task<ApiResponse<List<BookResponse>>> GetResponseAsync([Body] BookQueryRequest queryRequest,
        [Header("Authorization")] string jwtToken);

    [Post("/Book")]
    Task CreateAsync([Body] BookCreateRequest createRequest,
        [Header("Authorization")] string jwtToken);
    [Delete("/Book/{id}")]
    Task DeleteAsync(int id,
        [Header("Authorization")] string jwtToken);
}
