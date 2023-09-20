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
	public class WasteFormRepository : EfRepository<WasteForm>, IWasteFormRepository
	{
		public WasteFormRepository(DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
		{

		}

		public IEnumerable<WasteForm> WasteFormList()
		{
			// Aktif olanları ve silinme zamanı null olanları LINQ sorgusu ile filtreleyin.
			var list = context.Set<WasteForm>().Where(item => item.Aktif && item.SilinmeZamani == null)
				.Include(x=>x.District).ThenInclude(x=>x.City)
				.Include(x=>x.WasteCode)
				.ToList();
			return list;
		}


	}
}
