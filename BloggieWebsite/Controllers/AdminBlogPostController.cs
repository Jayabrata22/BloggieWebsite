using Azure;
using BloggieWebsite.Models.Domain;
using BloggieWebsite.Models.View_Model;
using BloggieWebsite.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloggieWebsite.Controllers
{
    public class AdminBlogPostController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository blogPostRepository;

        public AdminBlogPostController(ITagRepository tagRepository, IBlogPostRepository blogPostRepository)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepository = blogPostRepository;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var showtag = await tagRepository.GetAllTagsAsync();

            var Model = new AddBlogPostRequest
            {
                Tags = showtag.Select(x => new SelectListItem(text: x.DisplayName, value: x.Id.ToString()))
            };
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {
            var blogPost = new BlogPost
            {
                Heading = addBlogPostRequest.Heading,
                PageTitle = addBlogPostRequest.PageTitle,
                Content = addBlogPostRequest.Content,
                ShortDescription = addBlogPostRequest.ShortDescription,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                Urlhandle = addBlogPostRequest.Urlhandle,
                PublishedDate = addBlogPostRequest.PublishedDate,
                Author = addBlogPostRequest.Author,
                Visible = addBlogPostRequest.Visible,

            };

            var selectedtags = new List<Tag>();
            //Map Tags from selected tags
            foreach (var selectedTagId in addBlogPostRequest.SelectedTags)
            {
                var selectedTagIdAsGuid = Guid.Parse(selectedTagId);
                var existingtag = await tagRepository.GetTagAsync(selectedTagIdAsGuid);

                if (existingtag != null)
                {
                    selectedtags.Add(existingtag);
                }
            }

            //Mapping tags back to domain Model
            blogPost.Tags = selectedtags;

            await blogPostRepository.AddAsync(blogPost);

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewBlogPost = await blogPostRepository.GetAllPostsAsync();

            return View(viewBlogPost);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var Blog = await blogPostRepository.getAsync(id);
            var tags = await tagRepository.GetAllTagsAsync();
            if (Blog != null)
            {
                var editBlogPostRequest = new EditBlogPostRequest
                {
                    Id = Blog.Id,
                    Heading = Blog.Heading,
                    PageTitle = Blog.PageTitle,
                    PostTitle = Blog.PostTitle,
                    Content = Blog.Content,
                    ShortDescription = Blog.ShortDescription,
                    PublishedDate = Blog.PublishedDate,
                    FeaturedImageUrl = Blog.FeaturedImageUrl,
                    Urlhandle = Blog.Urlhandle,
                    Author = Blog.Author,
                    Visible = Blog.Visible,
                    Tags = tags.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),

                    SelectedTags = Blog.Tags.Select(x => x.Id.ToString()).ToArray()

                };

                return View(editBlogPostRequest);

            }
            return View("Sorry! No Blog Post Found.");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBlogPostRequest editBlogPostRequest)
        {
            var blogPost = new BlogPost
            {
                Id = editBlogPostRequest.Id,
                Heading = editBlogPostRequest.Heading,
                PageTitle = editBlogPostRequest.PageTitle,
                PostTitle = editBlogPostRequest.PostTitle,
                Content = editBlogPostRequest.Content,
                ShortDescription = editBlogPostRequest.ShortDescription,
                FeaturedImageUrl = editBlogPostRequest.FeaturedImageUrl,
                Urlhandle = editBlogPostRequest.Urlhandle,
                PublishedDate = editBlogPostRequest.PublishedDate,
                Author = editBlogPostRequest.Author,
                Visible = editBlogPostRequest.Visible,
            };
            var selectedtags = new List<Tag>();
            //Map Tags from selected tags
            foreach (var selectedTag in editBlogPostRequest.SelectedTags)
            {
                if (Guid.TryParse(selectedTag, out var tags))
                {
                    var existingtag = await tagRepository.GetTagAsync(tags);
                    if (existingtag != null)
                    {
                        selectedtags.Add(existingtag);
                    }
                }
                

                
            }

            blogPost.Tags = selectedtags;

            //Mapping tags back to domain Model

            var updatedBlogPost = await blogPostRepository.UpdateAsync(blogPost);
            if (updatedBlogPost != null)
            {

            }
            else
            {

            }
            return RedirectToAction("List", new { id = editBlogPostRequest.Id });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditBlogPostRequest editBlogPostRequest)
        {
            var Blog = await blogPostRepository.DeleteAsync(editBlogPostRequest.Id);
            if (Blog != null)
            {
                return RedirectToAction("List");

            }

            return RedirectToAction("Edit", new { ID = editBlogPostRequest.Id });
        }
    }
}
