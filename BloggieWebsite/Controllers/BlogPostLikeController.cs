using BloggieWebsite.Models.Domain;
using BloggieWebsite.Models.View_Model;
using BloggieWebsite.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostLikeController : ControllerBase
    {
        private readonly IBlogPostLikesRepository blogPostLikesRepository;

        public BlogPostLikeController(IBlogPostLikesRepository blogPostLikesRepository)
        {
            this.blogPostLikesRepository = blogPostLikesRepository;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
        {
            if (addLikeRequest != null)
            {
                var model = new BlogPostLikes
                {
                    BlogPostId = addLikeRequest.BlogPostId,
                    UserId = addLikeRequest.UserId,
                };
                await blogPostLikesRepository.addLikesForBLogs(model);


            }
            return Ok(0);
        }

        [HttpGet]
        [Route("{BlogPostId:Guid}/totalLikes")]
        public async Task<IActionResult> GetLikes([FromRoute] Guid BlogPostId)
        {
            var totalLikes = await blogPostLikesRepository.GetTotalLikesAsync(BlogPostId);

            return Ok(totalLikes);
        }
    }
}
