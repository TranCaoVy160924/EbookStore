using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;

namespace EbookStore.Client.ExternalService.ImageHostService;

public class CloudinaryHelper : IImageHostHelper
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryHelper()
    {
        DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
        _cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
        _cloudinary.Api.Secure = true;
    }

    public string UploadImage(IFormFile imagefile)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(imagefile.FileName, imagefile.OpenReadStream()),
        };
        var uploadResult = _cloudinary.Upload(uploadParams);

        return TransformUploadingImage(uploadResult.PublicId);
    }

    private string TransformUploadingImage(string imageName)
    {
        var myTransformation = _cloudinary.Api.UrlImgUp.Transform(new Transformation()
            .Width(100).Height(100));

        return myTransformation.BuildUrl(imageName);
    }
}
