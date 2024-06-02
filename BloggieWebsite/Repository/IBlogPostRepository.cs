using BloggieWebsite.Models.Domain;

namespace BloggieWebsite.Repository
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllPostsAsync();

        Task<BlogPost?> getAsync(Guid id);

        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);

        Task<BlogPost> GetUrlHandelAsync(string urlHandel);
        Task<IEnumerable<BlogPost>> GetBlogPostsByTagsAsync(IEnumerable<Tag> tags);
    }
}
