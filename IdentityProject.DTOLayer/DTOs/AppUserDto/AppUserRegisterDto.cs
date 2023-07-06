using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProject.DTOLayer.DTOs.AppUserDto
{
    public class AppUserRegisterDto
    {
        [Required(ErrorMessage ="Zorunlu Alan")]
        [Display(Name="İsim")]
        [MaxLength(30, ErrorMessage = "En fazla 30 Karakter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "İsim")]
        [MaxLength(30, ErrorMessage = "En fazla 30 Karakter")]
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
      
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
