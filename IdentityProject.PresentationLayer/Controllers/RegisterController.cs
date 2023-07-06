using IdentityProject.EntityLayer.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityProject.DTOLayer.DTOs.AppUserDto;
using Microsoft.AspNetCore.Identity;



namespace IdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;

        public RegisterController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto request)
        {
            if (ModelState.IsValid)
            {
                AppUser appUserRegister = new AppUser()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    UserName = request.Username,
                    Email = request.Mail,
                    
                };

                var result = await _userManager.CreateAsync(appUserRegister,request.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
            }
            return View();
        }
    }
}
