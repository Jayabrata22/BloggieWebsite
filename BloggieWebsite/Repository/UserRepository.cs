using BloggieWebsite.Data;
using BloggieWebsite.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebsite.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AuthenticationDbContext authenticationDb;

		public UserRepository(AuthenticationDbContext authenticationDb)
        {
			this.authenticationDb = authenticationDb;
		}

       

        public async Task<IEnumerable<IdentityUser>> GetAll()
		{
			var users = await authenticationDb.Users.ToListAsync();
			var superadminUser = await authenticationDb.Users.FirstOrDefaultAsync(x => x.Email == "SuparAdmin@bloggie.com");
			if (superadminUser != null)
			{
				users.Remove(superadminUser);
			}
			return users;
		}

      
    }
}
