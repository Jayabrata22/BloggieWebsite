
using BloggieWebsite.Models.View_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModelRequest registerViewModelRequest)
        {
            var User = new IdentityUser
            {
                UserName = registerViewModelRequest.UserName,
                Email = registerViewModelRequest.Email,

            };
           var IdentityUser = await userManager.CreateAsync(User, registerViewModelRequest.Password);

            if(IdentityUser.Succeeded)
            {
                //Assign this user the Normal ROle
                var IdentityRoleResult = await userManager.AddToRoleAsync(User, "User");

                if(IdentityRoleResult.Succeeded)
                {
                    //SHow Success Notification or return to Login Page
                    return RedirectToAction("Login");
                }
            }

            return View();
        }
    }
}
