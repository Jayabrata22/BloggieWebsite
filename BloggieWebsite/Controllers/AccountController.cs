
using BloggieWebsite.Models.View_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloggieWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public  IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public  IActionResult Login(string ReturnUrl)
        {
            var Model = new LoginViewModelRequest
            {
                ReturnUrl = ReturnUrl,
            };
            return View(Model);
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModelRequest loginViewModelRequest)
        {
            var signInResult= await signInManager.PasswordSignInAsync(loginViewModelRequest.UserName,loginViewModelRequest.Password,false,false);
            
            if(signInResult.Succeeded && signInResult != null)
            {
                if (!string.IsNullOrEmpty(loginViewModelRequest.ReturnUrl))
                {
                         return Redirect(loginViewModelRequest.ReturnUrl);    
                }
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
