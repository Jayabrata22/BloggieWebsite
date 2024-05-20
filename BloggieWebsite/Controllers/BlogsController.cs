using BloggieWebsite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebsite.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task<IActionResult> Index(string urlHandel)
        {
            var ShowBlog = await blogPostRepository.GetUrlHandelAsync(urlHandel); 

            return View(ShowBlog);
        }
    }
}
