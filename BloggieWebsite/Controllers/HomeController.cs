using BloggieWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BloggieWebsite.Repository;
using BloggieWebsite.Models.View_Model;

namespace BloggieWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ITagRepository tagRepository;

        public HomeController(ILogger<HomeController> logger, IBlogPostRepository blogPostRepository, ITagRepository tagRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index()
        {
            var blogPostsInHomePage = await blogPostRepository.GetAllPostsAsync();
            var tagsInHomePage = await tagRepository.GetAllTagsAsync();
            var model = new HomeViewModel
            {
                BlogPosts = blogPostsInHomePage,
                Tags = tagsInHomePage,
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
