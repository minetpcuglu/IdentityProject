using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntiityFramework;
using EntitiesLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
	public class DistrictRepository : EfRepository<District>, IDistrictRepository
	{
		public DistrictRepository(DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
		{

		}

		public IEnumerable<District> DistrictList()
		{
			// Aktif olanları ve silinme zamanı null olanları LINQ sorgusu ile filtreleyin.
			var list = context.Set<District>().Where(item => item.Aktif && item.SilinmeZamani == null).Include(x=>x.City).ToList();
			return list;
		}


	}
}
