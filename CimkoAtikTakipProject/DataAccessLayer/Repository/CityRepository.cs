using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntiityFramework;
using EntitiesLayer;
using Microsoft.AspNetCore.Http;

namespace DataAccessLayer.Repository
{
	public class CityRepository : EfRepository<City>, ICityRepository
	{
		public CityRepository(DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
		{

		}

		public IEnumerable<City> CityList()
		{
			// Aktif olanları ve silinme zamanı null olanları LINQ sorgusu ile filtreleyin.
			var list = context.Set<City>().Where(item => item.Aktif && item.SilinmeZamani == null).ToList();
			return list;
		}


	}
}

