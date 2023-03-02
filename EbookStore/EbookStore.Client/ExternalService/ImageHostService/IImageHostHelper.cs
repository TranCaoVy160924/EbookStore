namespace EbookStore.Client.ExternalService.ImageHostService;

public interface IImageHostHelper
{
    string UploadImage(IFormFile imagefile);
}
