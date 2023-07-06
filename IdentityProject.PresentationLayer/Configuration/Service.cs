using IdentityProject.BusinessLayer.CustomerAccount;
using IdentityProject.DataAccessLayer.Abstract;
using IdentityProject.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityProject.PresentationLayer.Configuration
{
	public static class Service
	{
		/// <summary>
		/// When the program runs, services are injected.
		/// </summary>
		/// <param name="services"></param>
		public static void AddMyServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<ICustomerAccountService, CustomerAccountService>();
			services.AddScoped<ICustomerAccountRepository, CustomerAccountRepository>();
		}
	}
}
