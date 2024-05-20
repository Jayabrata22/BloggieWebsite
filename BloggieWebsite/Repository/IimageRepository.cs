namespace BloggieWebsite.Repository
{
    public interface IimageRepository
    {
        Task<string> UploadImagesAsync(IFormFile file);
    }
}
