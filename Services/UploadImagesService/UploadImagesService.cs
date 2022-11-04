using Microsoft.AspNetCore.Http;


namespace Services.UploadImageService
{
    public class UploadImagesService : IUploadImagesService
    {
        public ICollection<string> UploadImages(ICollection<IFormFile> files)
        {
            var supportedTypes = new[] { ".png", ".jpg", ".jpeg" };
            List<string> filePaths = new List<string>();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string extension = Path.GetExtension(file.FileName);
                        if (!supportedTypes.Contains(extension))
                            continue;

                        string filename = Guid.NewGuid().ToString();
                        filePaths.Add(filename + extension);
                        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", filename);

                        using (FileStream fileStream = System.IO.File.Create(uploadPath+extension))
                        {
                            file.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return filePaths;
        }
    }
}
