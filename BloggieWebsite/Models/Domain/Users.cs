using BloggieWebsite.Models.View_Model;
using Microsoft.EntityFrameworkCore;

namespace BloggieWebsite.Models.Domain
{
	

	public class Users
	{
		
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public string? ProfilePictureUrl { get; set; }  // Nullable string
		public string? FullName { get; set; }           // Nullable string
		public string? JobTitle { get; set; }           // Nullable string
		public string? Location { get; set; }           // Nullable string
		public string? Email { get; set; }              // Nullable string
		public string? Phone { get; set; }              // Nullable string
		public string? Mobile { get; set; }             // Nullable string
		public string? Address { get; set; }            // Nullable string
		public string? Website { get; set; }            // Nullable string
		public string? Github { get; set; }             // Nullable string
		public string? Twitter { get; set; }            // Nullable string
		public string? Instagram { get; set; }          // Nullable string
		public string? Facebook { get; set; }           // Nullable string
		public int? WebDesignProgress { get; set; }     // Nullable int
		public int? WebsiteMarkupProgress { get; set; } // Nullable int
		public int? OnePageProgress { get; set; }       // Nullable int
		public int? MobileTemplateProgress { get; set; }// Nullable int
		public int? BackendAPIProgress { get; set; }    // Nullable int

        public List<User> User { get; set; }
    }

}
