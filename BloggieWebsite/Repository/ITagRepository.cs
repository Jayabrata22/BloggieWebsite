using BloggieWebsite.Models.Domain;

namespace BloggieWebsite.Repository
{
    public interface ITagRepository
    {
         Task<IEnumerable<Tag>> GetAllTagsAsync();

        Task<Tag> GetTagAsync(Guid id);

        Task<Tag> AddTagAsync(Tag tag); 

        Task<Tag?> UpdateTagAsync(Tag tag);
        Task<Tag?> DeleteTag(Guid id);

    }
}
