using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.DTOLayer.DTOs.AppUserDto;

namespace IdentityProject.DTOLayer.DTOs.CustomerAccountDto
{
    public class CustomerAccountDto:BaseDto.Base
    {
        public string Number { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string BankBranch { get; set; }
        public int AppUserID { get; set; }
        public AppUserRegisterDto AppUser { get; set; }
    }
}
