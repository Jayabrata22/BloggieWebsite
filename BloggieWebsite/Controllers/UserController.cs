using BloggieWebsite.Models.View_Model;
using BloggieWebsite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebsite.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserServiceRespository userServiceRespository;

		public UserController(IUserServiceRespository userServiceRespository)
		{
			this.userServiceRespository = userServiceRespository;
		}


		[HttpGet]
		public IActionResult ViewProfile()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Edit()
		{
			var userProfile = userServiceRespository.GetUserProfile(User.Identity.Name);
			return View(userProfile);
			
		}

		[HttpPost]
		public async Task<IActionResult> SaveProfile(UserProfileViewModel model)
		{
			if (ModelState.IsValid)
			{
				await userServiceRespository.UpdateUserProfile(model);
				return RedirectToAction("EditProfile");
			}

			return View("EditProfile", model);
		}
	}
}
