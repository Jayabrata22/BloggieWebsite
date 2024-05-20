using BloggieWebsite.Models.Domain;

namespace BloggieWebsite.Models.View_Model
{
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<BlogPostLikes> BlogPostLikes { get; set; }
    }
}
