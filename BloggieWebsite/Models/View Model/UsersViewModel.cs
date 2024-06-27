namespace BloggieWebsite.Models.View_Model
{
	public class UsersViewModel
	{
		public List<User> Users { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public bool AdminRoleCheck { get; set; }
	}
}
