using BloggieWebsite.Data;
using BloggieWebsite.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebsite.Repository
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BloggieDbContext _context;

        public BlogPostCommentRepository(BloggieDbContext _context)
        {
            this._context = _context;
        }

        public async  Task<BlogPostComment> AddCommentAsync(BlogPostComment comment)
        {
            await _context.PostComments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async  Task<IEnumerable<BlogPostComment>> GetAllCommentsByBlogIDAsync(Guid blogPostId)
        {
            return await _context.PostComments.Where(x => x.BlogPostID == blogPostId).ToListAsync();
        }
    }
}
