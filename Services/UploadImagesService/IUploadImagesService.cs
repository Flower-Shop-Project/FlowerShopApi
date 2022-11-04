using Microsoft.AspNetCore.Http;


namespace Services.UploadImageService
{
    public interface IUploadImagesService
    {
        ICollection<string> UploadImages(ICollection<IFormFile> files);
    }
}
