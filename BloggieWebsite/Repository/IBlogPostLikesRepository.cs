using BloggieWebsite.Models.Domain;

namespace BloggieWebsite.Repository
{
    public interface IBlogPostLikesRepository
    {
        Task<int> GetTotalLikesAsync(Guid blogPostID);

        Task<IEnumerable<BlogPostLikes>> GetLikesForBlog(Guid blogPostID);
        Task<BlogPostLikes>addLikesForBLogs(BlogPostLikes blogPostLikes);
    }
}
