using BloggieWebsite.Models.Domain;

namespace BloggieWebsite.Models.View_Model
{
	public class UserProfileViewModel
	{
		public string UserName { get; set; }
		public string ProfilePictureUrl { get; set; }
		public string FullName { get; set; }
		public string JobTitle { get; set; }
		public string Location { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Address { get; set; }
		public string Website { get; set; }
		public string Github { get; set; }
		public string Twitter { get; set; }
		public string Instagram { get; set; }
		public string Facebook { get; set; }
		public int WebDesignProgress { get; set; }
		public int WebsiteMarkupProgress { get; set; }
		public int OnePageProgress { get; set; }
		public int MobileTemplateProgress { get; set; }
		public int BackendAPIProgress { get; set; }
	}
}
