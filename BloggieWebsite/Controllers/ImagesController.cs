using BloggieWebsite.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BloggieWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IimageRepository iimageRepository;

        public ImagesController(IimageRepository iimageRepository)
        {
            this.iimageRepository = iimageRepository;
        }


        [HttpPost]
        public async Task<IActionResult> UploadImagesAsync(IFormFile file)
        {
            var imageurl  = await iimageRepository.UploadImagesAsync(file);
            if(imageurl == null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            };

            return new JsonResult(new { link = imageurl });
        }
    }
}
