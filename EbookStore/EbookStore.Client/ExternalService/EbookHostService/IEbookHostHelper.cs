namespace EbookStore.Client.ExternalService.EbookHostService;

public interface IEbookHostHelper
{
    Task<string> Upload(IFormFile ebookFile);
}
