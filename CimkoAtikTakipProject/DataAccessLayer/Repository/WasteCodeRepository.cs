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
	public class WasteCodeRepository : EfRepository<WasteCode>, IWasteCodeRepository
	{
		public WasteCodeRepository(DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
		{

		}

		public IEnumerable<WasteCode> WasteCodeList()
		{
			// Aktif olanları ve silinme zamanı null olanları LINQ sorgusu ile filtreleyin.
			var list = context.Set<WasteCode>().Where(item => item.Aktif && item.SilinmeZamani == null).ToList();
			return list;
		}


	}
}
