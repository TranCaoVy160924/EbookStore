using EbookStore.Contract.ViewModel.LibraryItem.Response;
using EbookStore.Contract.ViewModel.LibraryItem.Request;
using Refit;

namespace EbookStore.Client.RefitClient;

public interface ILibraryClient
{
    [Post("/Book/Search/")]
    Task<ApiResponse<List<LibraryItemResponse>>> GetResponseAsync([Body] LibraryItemQueryRequest queryRequest);
}
