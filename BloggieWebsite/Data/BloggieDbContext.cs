using BloggieWebsite.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebsite.Data
{
	public class BloggieDbContext : DbContext
	{
		public BloggieDbContext(DbContextOptions<BloggieDbContext> options) : base(options)
		{

		}

		public DbSet<BlogPostComment> PostComments { get; set; }
		public DbSet<BlogPostLikes> BlogPostLike { get; set; }
		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<Tag> Tags { get; set; }

		public DbSet<Users> Users { get; set; }

	}
}
