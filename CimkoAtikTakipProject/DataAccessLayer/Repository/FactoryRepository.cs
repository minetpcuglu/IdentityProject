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

namespace DataAccessLayer.Repository
{
	public class FactoryRepository : EfRepository<Factory>, IFactoryRepository
	{
		public FactoryRepository(DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
		{

		}

		public IEnumerable<Factory> FactoryList()
		{
			// Aktif olanları ve silinme zamanı null olanları LINQ sorgusu ile filtreleyin.
			var list = context.Set<Factory>().Where(item => item.Aktif && item.SilinmeZamani == null).ToList();
			return list;
		}


	}
}
