namespace BloggieWebsite.Models.View_Model
{
    public class AddLikeRequest
    {
        public Guid BlogPostId { get; set; }

        public Guid UserId { get; set; }    
    }
}
