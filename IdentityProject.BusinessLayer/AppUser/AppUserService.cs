using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.BusinessLayer.CustomerAccount;
using IdentityProject.DTOLayer.DTOs.AppUserDto;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;

namespace IdentityProject.BusinessLayer.AppUser
{
	public class AppUserService : IAppUserService
	{
		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityProject.EntityLayer.Concrete.AppUser> _userManager;

		public AppUserService(UserManager<EntityLayer.Concrete.AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<(bool, List<string>)> AddAppUserAsync(AppUserRequest request)
		{
			Random random = new Random();
			int code = random.Next(1000, 1000000);
			var appUserRegister = new IdentityProject.EntityLayer.Concrete.AppUser()
			{
				Name = request.Name,
				Surname = request.Surname,
				UserName = request.Username,
				Email = request.Mail,
				City = "123",
				District = "123",
				ImageUrl = "123",
				ConfirmCode = code
			};

			var result = await _userManager.CreateAsync(appUserRegister, request.Password);

			if (!result.Succeeded)
			{
					if (!result.Succeeded)
					{
						List<string> errors = result.Errors.Select(e => e.Description).ToList();
						return (false, errors);
					}		
			}
			#region SMTP MAİL
			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("Güvenme insanların vefasına bugün överler, yarın söverler.", "yalcinmete.g4@gmail.com");
			MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUserRegister.Email);
			mimeMessage.From.Add(mailboxAddressFrom);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = "Kayıt işlemi gercekleştirmek için Onay kodunuz: " + code;
			mimeMessage.Body = bodyBuilder.ToMessageBody();
			mimeMessage.Subject = "Mineden Mailiniz Var !";

			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Connect("smtp.gmail.com", 587, false);
			smtpClient.Authenticate("minetopcuoglu6@gmail.com", "luinjceusvkzsnmm");
			smtpClient.Send(mimeMessage);
			smtpClient.Disconnect(true);
			#endregion

			smtpClient.Dispose();

			return (true, null);
		}
	}
}
