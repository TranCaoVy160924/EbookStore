using Dropbox.Api;
using Dropbox.Api.Files;
using EbookStore.Client.RefitClient;
using Microsoft.AspNetCore.DataProtection;
using NuGet.Configuration;
using System.Net.Http;
using System.Text;

namespace EbookStore.Client.ExternalService.EbookHostService;

public class DropboxHelper : IEbookHostHelper
{
    private DropboxClient Dropbox;
    private readonly IDropboxClient _dropboxRefitClient;
    private const string TOKEN = "Y1h6HFGgbQ4AAAAAAAAAFRH2GmsvtyFU3L5C0Z3uMyg";
    private const string API_KEY = "rwv3peovwrk07a5";
    private const string API_SECRET = "en27g1yz91a3nvz";
    private const string FOLDER = "/sdfg";

    public DropboxHelper(IDropboxClient dropboxRefitClient)
    {
        _dropboxRefitClient = dropboxRefitClient;
        Dropbox = new DropboxClient(API_KEY, API_SECRET);
    }

    public async Task<string> Upload(IFormFile ebookFile)
    {
        //await GetDropbox();

        var fileName = ebookFile.FileName;
        using (var mem = new MemoryStream())
        {
            ebookFile.OpenReadStream().CopyTo(mem);
            var updated = await Dropbox.Files.UploadAsync(
                FOLDER + "/" + fileName,
                WriteMode.Overwrite.Instance,
                body: mem);
        }

        return fileName;
    }

    private async Task GetDropbox()
    {
        string authToken = await _dropboxRefitClient.GetAuthTokenAsync(API_KEY);
        Dropbox = new DropboxClient(TOKEN);
    }

    //private async Task GetToken()
    //{
    //    // Instantiate a DropboxClient with your app key and app secret
    //    var client = new DropboxClient(API_KEY, API_SECRET);

    //    // Generate an authorization URL
    //    var authorizeUri = client.Auth.GetAuthorizeUri(new string[] { "files.metadata.read" });

    //    // Redirect the user to the authorization URL

    //    // When the user is redirected back to your redirect URI, retrieve the authorization code
    //    string authorizationCode = "<authorization-code>";

    //    // Exchange the authorization code for an access token
    //    var token = await client.Auth.TokenFromOAuth1Async(new OAuth1AuthorizationCode(authorizationCode));

    //    // Store the access token for future use
    //    var accessToken = token.OAuthToken;
    //}
}
