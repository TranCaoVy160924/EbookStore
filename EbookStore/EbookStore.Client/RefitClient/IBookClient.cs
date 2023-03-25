using EbookStore.Contract.ViewModel.Book.BookQueryRequest;
using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.Book.Request;
using EbookStore.Contract.ViewModel.Book.Response;
using EbookStore.Contract.ViewModel.Genre.Response;
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

    [Get("/Book/NotOnSale")]
    Task<List<BookResponse>> GetNotOnSaleAsync();
    [Post("/Book/Search/")]
    Task<ApiResponse<List<BookResponse>>> GetResponseAsync([Body] BookQueryRequest queryRequest);

    [Delete("/Book/{id}")]
    Task DeleteAsync(int id,
        [Header("Authorization")] string jwtToken);
    [Post("/Book")]
    Task CreateAsync([Body] BookCreateRequest createRequest,
        [Header("Authorization")] string jwtToken);
    [Patch("/Book")]
    Task UpdateAsync([Body] BookUpdateRequest updateRequest,
        [Header("Authorization")] string jwtToken);
    [Get("/Book/{id}")]
    Task<ApiResponse<BookDetailResponse>> GetOneAsync(int id);
}
