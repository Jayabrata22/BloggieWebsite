using BloggieWebsite.Models.Domain;
using BloggieWebsite.Models.View_Model;
using BloggieWebsite.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebsite.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikesRepository blogPostLikesRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository blogPostCommentRepository;

        public BlogsController(IBlogPostRepository blogPostRepository, IBlogPostLikesRepository blogPostLikesRepository, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, IBlogPostCommentRepository blogPostCommentRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikesRepository = blogPostLikesRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.blogPostCommentRepository = blogPostCommentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string urlHandel)
        {
            var Liked = false;
            var ShowBlog = await blogPostRepository.GetUrlHandelAsync(urlHandel);
            var blogpostLikesViewMOdel = new BlogDetailsViewModel();


            if (ShowBlog != null)
            {

                var totalLikes = await blogPostLikesRepository.GetTotalLikesAsync(ShowBlog.Id);
                if (signInManager.IsSignedIn(User))
                {
                    var LikesForBlogs = await blogPostLikesRepository.GetLikesForBlog(ShowBlog.Id);

                    var userId = userManager.GetUserId(User);
                    if (userId != null)
                    {
                        var LikeFromUser = LikesForBlogs.FirstOrDefault(x => x.UserId == Guid.Parse(userId));
                        Liked = LikeFromUser != null;
                    }
                }
                var BlogCommentDomainModel = await blogPostCommentRepository.GetAllCommentsByBlogIDAsync(ShowBlog.Id);

                var BlogCommentforView = new List<BlogComment>();
                foreach (var blogComment in BlogCommentDomainModel)
                {
                    BlogCommentforView.Add(new BlogComment
                    {
                        Comment = blogComment.Description,
                        DateAddes = blogComment.DateAdded,
                        UserName = (await userManager.FindByIdAsync(blogComment.UserId.ToString())).UserName,
                    });
                }

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
                    TotalLikes = totalLikes,
                    Liked = Liked,
                    Comments = BlogCommentforView


                };
               
            }
            return View(blogpostLikesViewMOdel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {

            if (signInManager.IsSignedIn(User))
            {
                var domainModel = new BlogPostComment
                {
                    BlogPostID = blogDetailsViewModel.Id,
                    Description = blogDetailsViewModel.commentDescription,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    DateAdded = DateTime.Now,
                };


                await blogPostCommentRepository.AddCommentAsync(domainModel);
                return RedirectToAction("Index", "Home", new { Urlhandel = blogDetailsViewModel.Urlhandle });
            }
            else
            {
                return View();
            }



        }

    }
}