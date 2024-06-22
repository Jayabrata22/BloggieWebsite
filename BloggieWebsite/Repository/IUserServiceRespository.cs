using BloggieWebsite.Models.View_Model;

namespace BloggieWebsite.Repository
{
	public interface IUserServiceRespository
	{
		Task<UserProfileViewModel> GetUserProfile(string username);
		Task UpdateUserProfile(UserProfileViewModel model);
	}
}
