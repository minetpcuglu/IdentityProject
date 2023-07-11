using IdentityProject.EntityLayer.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityProject.DTOLayer.DTOs.AppUserDto;
using Microsoft.AspNetCore.Identity;
using IdentityProject.BusinessLayer.AppUser;

namespace IdentityProject.PresentationLayer.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IAppUserService _appUserService;
		public RegisterController(BusinessLayer.AppUser.IAppUserService appUserService)
		{
			_appUserService = appUserService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(AppUserRequest request)
		{
			if (!ModelState.IsValid)
			{		
				var result = await _appUserService.AddAppUserAsync(request);
				if (!result.Item1)
				{
					List<string> errors = result.Item2;
					string errorMessage = string.Join(" ", errors);
					ModelState.AddModelError("", errorMessage);
				}
				else
					return RedirectToAction("Index", "ConfirmMail");
			}
			return View();
		}
	}
}

