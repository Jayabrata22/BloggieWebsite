using BloggieWebsite.Models.View_Model;
using BloggieWebsite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebsite.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikesRepository blogPostLikesRepository;

        public BlogsController(IBlogPostRepository blogPostRepository, IBlogPostLikesRepository blogPostLikesRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikesRepository = blogPostLikesRepository;
        }
        public async Task<IActionResult> Index(string urlHandel)
        {
            var ShowBlog = await blogPostRepository.GetUrlHandelAsync(urlHandel);
            var blogpostLikesViewMOdel = new BlogDetailsViewModel();


            if (ShowBlog != null)
            {
                
                var totalLikes = await blogPostLikesRepository.GetTotalLikesAsync(ShowBlog.Id);
                 blogpostLikesViewMOdel = new BlogDetailsViewModel
                {
                    Id = ShowBlog.Id,
                    Content = ShowBlog.Content,
                    PageTitle = ShowBlog.PageTitle,
                    PostTitle = ShowBlog.PostTitle,
                    ShortDescription = ShowBlog.ShortDescription,
                    Author = ShowBlog.Author,
                    PublishedDate = ShowBlog.PublishedDate,
                    FeaturedImageUrl = ShowBlog.FeaturedImageUrl,
                    Heading = ShowBlog.Heading,
                    Tags = ShowBlog.Tags,
                    Urlhandle = ShowBlog.Urlhandle,
                    Visible = ShowBlog.Visible,
                    TotalLikes = totalLikes
                };
            }
            return View(blogpostLikesViewMOdel);
        }
    }
}
