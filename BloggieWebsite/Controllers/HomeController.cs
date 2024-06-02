using BloggieWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BloggieWebsite.Repository;
using BloggieWebsite.Models.View_Model;
using BloggieWebsite.Models.Domain;

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

        [HttpGet]
        public IActionResult About()
        {

            return View();
        }

        [HttpGet]
        public IActionResult FAQ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(new List<BlogPost>());
            }
            var tags = await tagRepository.SearchTagsAsync(query);
            var BlogPosts = await blogPostRepository.GetBlogPostsByTagsAsync(tags);

            return View(BlogPosts);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
