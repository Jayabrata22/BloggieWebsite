
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Net;

namespace BloggieWebsite.Repository
{
    public class CloudImageRepository : IimageRepository
    {
        private readonly IConfiguration configuration;
        private readonly Account account;

        public CloudImageRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            account = new Account(
                configuration.GetSection("Cloudinary")["cloud_name"],
                configuration.GetSection("Cloudinary")["api_key"],
                configuration.GetSection("Cloudinary")["api_secret"]);
        }
        public  async Task<string> UploadImagesAsync(IFormFile file)
        {
            var client = new Cloudinary(account);
            var uploadparam = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName,
                //PublicId = "olympic_flag"
            };

            var uploadResult = await client.UploadAsync(uploadparam);

            if(uploadResult != null && uploadResult.StatusCode == HttpStatusCode.OK)
            {
                return uploadResult.SecureUri.ToString();
            }
            
            return null;
        }
    }
}
