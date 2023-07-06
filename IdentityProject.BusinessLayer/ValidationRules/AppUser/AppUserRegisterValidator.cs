using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IdentityProject.DTOLayer.DTOs.AppUserDto;

namespace IdentityProject.BusinessLayer.ValidationRules.AppUser
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(y=>y.Password).WithMessage("Şifre Tekrarı boş geçilemez veya şifreler eşleşmiyor");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.Mail).EmailAddress().NotEmpty().WithMessage("Mail boş geçilemez veya Mail Formatında yazın");
            RuleFor(x => x.Username).MaximumLength(3).MaximumLength(50).NotEmpty().WithMessage("Kullanıcı Adı 3-50 karakter arasında olmalıdır");
        }

    }
}
