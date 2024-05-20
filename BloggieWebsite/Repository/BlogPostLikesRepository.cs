
using BloggieWebsite.Data;
using BloggieWebsite.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebsite.Repository
{
    public class BlogPostLikesRepository : IBlogPostLikesRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public BlogPostLikesRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<int> GetTotalLikesAsync(Guid blogPostID)
        {
            return await bloggieDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostID);
        }

         async Task<BlogPostLikes> IBlogPostLikesRepository.addLikesForBLogs(BlogPostLikes blogPostLikes)
        {
            await bloggieDbContext.BlogPostLike.AddAsync(blogPostLikes);
            await bloggieDbContext.SaveChangesAsync();
            return blogPostLikes;
        }
    }
}
