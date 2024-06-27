using BloggieWebsite.Models.View_Model;
using BloggieWebsite.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebsite.Controllers
{
	[Authorize(Roles ="Admin")]
	public class AdminUsersController : Controller
	{
		private readonly IUserRepository userRepository;
        private readonly UserManager<IdentityUser> userManager;

        public AdminUsersController(IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
			this.userRepository = userRepository;
            this.userManager = userManager;
        }
		[HttpGet]
        public async Task<IActionResult> List()
		{
			var users = await userRepository.GetAll();

			var userViewModels = new UsersViewModel();
			userViewModels.Users = new List<User>(); 
				
			foreach (var user in users)
			{
				userViewModels.Users.Add(new Models.View_Model.User
				{
					Id = Guid.Parse(user.Id),
					Name = user.UserName,
					Email = user.Email,
					
				});

			}

			return View(userViewModels);
		}

		[HttpPost]
		public async Task<IActionResult> List(UsersViewModel Request)
		{
			var identityuser = new IdentityUser
			{ 
				UserName = Request.UserName,
				Email = Request.Email 
			};

			var IdentityResult = await userManager.CreateAsync(identityuser, Request.Password);
			if(IdentityResult is not null)
			{
                if (IdentityResult.Succeeded)
                {
                    var roles = new List<string> { "User" };
					if(Request.AdminRoleCheck == true)
                    {
                        roles.Add("Admin");
                    }

					IdentityResult = await userManager.AddToRolesAsync(identityuser, roles);

					if(IdentityResult is not null && IdentityResult.Succeeded)
                    {
						TempData["Message"] = $"User {Request.UserName} created successfully.";
						return RedirectToAction("List","AdminUsers");
                    }
                }
            }
			return View();
			
		}


		[HttpPost]
		public async Task<IActionResult> Delete(Guid id)
		{

			var user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
				var identityresult = await userManager.DeleteAsync(user);
				if (identityresult is not null && identityresult.Succeeded)
				{
					TempData["Message"] = $"User {user.UserName} deleted successfully.";
					return RedirectToAction("List", "AdminUsers");
				}
				
            }

            return View();

		}

		
	}
}
