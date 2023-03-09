using EbookStore.Contract.ViewModel.Book.BookResponse;
using EbookStore.Contract.ViewModel.WishItem.Request;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace EbookStore.Client.RefitClient;

[Headers("Content-Type: application/json")]
public interface IWishlistClient
{
    [Post("/Wishlist/{bookId}/")]
    Task AddBookToWishlistAsync(int bookId, [Header("Authorization")] string jwtToken);

    [Post("/Wishlist/Search/")]
    Task<ApiResponse<List<BookResponse>>> GetResponseAsync([Body] WishItemQueryRequest queryRequest,
                                                        [Header("Authorization")] string jwtToken);
}
