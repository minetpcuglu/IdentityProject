using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.BusinessLayer.CustomerAccount;

namespace IdentityProject.BusinessLayer.AppUser
{
	public interface IAppUserService
	{
		Task<(bool, List<string>)> AddAppUserAsync(AppUserRequest request);
		//Task<bool> AddAppUserAsync(AppUserRequest request);
		
	}
}
