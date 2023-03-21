using Refit;

namespace EbookStore.Client.RefitClient;

public interface IDropboxClient
{
    [Get("/oauth2/authorize?client_id={API_KEY}&response_type=code")]
    Task<string> GetAuthTokenAsync(string API_KEY);
}
