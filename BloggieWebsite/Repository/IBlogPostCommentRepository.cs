using BloggieWebsite.Models.Domain;

namespace BloggieWebsite.Repository
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddCommentAsync(BlogPostComment comment);

        Task<IEnumerable<BlogPostComment>> GetAllCommentsByBlogIDAsync(Guid blogPostId);
    }
}
