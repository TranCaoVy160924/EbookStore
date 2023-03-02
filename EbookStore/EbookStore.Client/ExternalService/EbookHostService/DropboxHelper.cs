using Dropbox.Api;
using Dropbox.Api.Files;
using System.Text;

namespace EbookStore.Client.ExternalService.EbookHostService;

public class DropboxHelper : IEbookHostHelper
{
    private readonly DropboxClient _dropbox;
    private const string TOKEN = "sl.BZz345lt9b6cn0EkfAYHraC7K4lyT-Xajdryhe6r9Yt7FtAU3CJXtVBrpCvdBWa41PXCNIRrNBf1Yg_TEPFRSjQqIXZ48CAlFLiqIacNdUC-slPxpSOQWd12ghkDFI-pIZHezJA8QqSl";
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
