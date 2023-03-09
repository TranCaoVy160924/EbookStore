using Dropbox.Api;
using Dropbox.Api.Files;
using System.Text;

namespace EbookStore.Client.ExternalService.EbookHostService;

public class DropboxHelper : IEbookHostHelper
{
    private readonly DropboxClient _dropbox;
    private const string TOKEN = "sl.BaR0DFXD16WWsyQLNjmECsfw4KxOhK6MfIEQGV7Z4q_3Tb_HK-x7dURoaYZ3sMetEjyRGi-2_EVkOeQP-OwyBWTXbvn7GtIfYcNFODcsX87eX8OKeWpF9rHLTlbVWAVYoMdMA1_6ViTf";
    private const string FOLDER = "/sdfg";

    public DropboxHelper()
    {
        _dropbox = new DropboxClient(TOKEN);
    }

    public async Task<string> Upload(IFormFile ebookFile)
    {
        var fileName = ebookFile.FileName;
        using (var mem = new MemoryStream())
        {
            ebookFile.OpenReadStream().CopyTo(mem);
            var updated = await _dropbox.Files.UploadAsync(
                FOLDER + "/" + fileName,
                WriteMode.Overwrite.Instance,
                body: mem);
        }

        return fileName;
    }
}
