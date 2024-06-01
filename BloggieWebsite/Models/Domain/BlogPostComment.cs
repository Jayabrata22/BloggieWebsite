namespace BloggieWebsite.Models.Domain
{
    public class BlogPostComment
    {
        public Guid Id { get; set; }
        public string Description { get; set; } 

        public Guid BlogPostID { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateAdded {  get; set; }
    }
}
