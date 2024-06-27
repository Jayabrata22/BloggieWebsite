using BloggieWebsite.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace BloggieWebsite.Repository
{
	public interface IUserRepository
	{
		Task<IEnumerable<IdentityUser>> GetAll();

		
	}
}
