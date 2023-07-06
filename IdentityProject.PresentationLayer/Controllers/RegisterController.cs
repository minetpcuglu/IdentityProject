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
            if (!ModelState.IsValid)
            {
                Random random = new Random();
                AppUser appUserRegister = new AppUser()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    UserName = request.Username,
                    Email = request.Mail,
                    City="Karabük",
                    District="bbb",
                    ImageUrl="cccc",
                    ConfirmCode=random.Next(1000,1000000)
                    
                };

                var result = await _userManager.CreateAsync(appUserRegister,request.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
