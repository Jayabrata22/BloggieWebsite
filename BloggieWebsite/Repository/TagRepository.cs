using BloggieWebsite.Data;
using BloggieWebsite.Models.Domain;
using BloggieWebsite.Models.View_Model;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebsite.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public TagRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<Tag> AddTagAsync(Tag tag)
        {
            await bloggieDbContext.Tags.AddAsync(tag);
            await bloggieDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> DeleteTag(Guid id)
        {
            var existingTag = await bloggieDbContext.Tags.FindAsync(id);
            if (existingTag != null)
            {
                bloggieDbContext.Remove(existingTag);
                await bloggieDbContext.SaveChangesAsync();

                return existingTag;
            }
            return null;    
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            
            return await bloggieDbContext.Tags.ToListAsync();
        }

        
        public async Task<Tag> GetTagAsync(Guid id)
        {
            return await bloggieDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Tag>> SearchTagsAsync(string keyword)
        {
            return await bloggieDbContext.Tags.Where(x=> x.Name.Contains(keyword)).ToListAsync();
        }

        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            var existingTag = await bloggieDbContext.Tags.FindAsync(tag.Id);
            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await bloggieDbContext.SaveChangesAsync();

                return existingTag;
            }
            return null;
        }
    }
}
