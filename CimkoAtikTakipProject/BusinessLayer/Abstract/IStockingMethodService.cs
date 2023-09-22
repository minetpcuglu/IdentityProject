using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.EntityFramework;
using EntitiesLayer.DTO;
using EntitiesLayer;

namespace BusinessLayer.Abstract
{
	public interface IStockingMethodService : IBaseService<StockingMethod>
	{
		public IEnumerable<StockingMethodDTO> GetAllStockingMethod();
		
	}
}
