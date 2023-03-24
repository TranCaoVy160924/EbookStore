using Refit;

namespace EbookStore.Client.RefitClient;

[Headers("Content-Type: application/json")]
public interface ILibraryItemClient
{
    [Post("/LibraryItem/{bookId}/")]
    Task AddBookToLibraryAsync(int bookId, [Header("Authorization")] string jwtToken);
}
