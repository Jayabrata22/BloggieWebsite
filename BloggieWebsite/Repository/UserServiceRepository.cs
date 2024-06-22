using BloggieWebsite.Data;
using BloggieWebsite.Models.View_Model;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebsite.Repository
{
	public class UserServiceRepository : IUserServiceRespository
	{
		private readonly BloggieDbContext bloggieDbContext;

		public UserServiceRepository(BloggieDbContext bloggieDbContext)
		{
			this.bloggieDbContext = bloggieDbContext;
		}
		public async  Task<UserProfileViewModel> GetUserProfile(string username)
		{
			var user = await bloggieDbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
			if (user == null)
			{
				return null;
			}

			return new UserProfileViewModel
			{
				ProfilePictureUrl = user.ProfilePictureUrl,
				FullName = user.FullName,
				JobTitle = user.JobTitle,
				Location = user.Location,
				Email = user.Email,
				Phone = user.Phone,
				Mobile = user.Mobile,
				Address = user.Address,
				Website = user.Website,
				Github = user.Github,
				Twitter = user.Twitter,
				Instagram = user.Instagram,
				Facebook = user.Facebook,
			};
		}

		public async Task UpdateUserProfile(UserProfileViewModel model)
		{
			var user = await bloggieDbContext.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
			if (user == null)
			{
				return;
			}

			user.ProfilePictureUrl = model.ProfilePictureUrl;
			user.FullName = model.FullName;
			user.JobTitle = model.JobTitle;
			user.Location = model.Location;
			user.Email = model.Email;
			user.Phone = model.Phone;
			user.Mobile = model.Mobile;
			user.Address = model.Address;
			user.Website = model.Website;
			user.Github = model.Github;
			user.Twitter = model.Twitter;
			user.Instagram = model.Instagram;
			user.Facebook = model.Facebook;

			bloggieDbContext.Users.Update(user);
			await bloggieDbContext.SaveChangesAsync();
		}
	}
	
}
