using Microsoft.CodeAnalysis;

namespace EbookStore.Client.ExternalService.EbookHostService;

public class SelfHostHelper : IEbookHostHelper
{
    private readonly IWebHostEnvironment _env;

    public SelfHostHelper(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> Upload(IFormFile ebookFile)
    {
        string fileName = ebookFile.FileName;
        string path = Path.Combine(_env.WebRootPath, "Ebook");
        string fullpath = Path.Combine(path, fileName);
        using (FileStream stream = new FileStream(fullpath, FileMode.Create))
        {
            // Copy the IFormFile to the FileStream
            await ebookFile.CopyToAsync(stream);
        }

        return fileName;
    }

    public string GetDownloadPath(string fileName)
    {
        string path = Path.Combine(_env.WebRootPath, "Ebook");
        string fullpath = Path.Combine(path, fileName);

        if (!System.IO.File.Exists(fullpath))
        {
            throw new Exception("File not exist");
        }

        return fullpath;
    }
}
