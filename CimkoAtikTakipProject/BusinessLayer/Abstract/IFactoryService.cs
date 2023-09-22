using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.DTO;
using EntitiesLayer;
using CoreLayer.DataAccess.EntityFramework;

namespace BusinessLayer.Abstract
{
	public interface IFactoryService : IBaseService<Factory>
	{
		public IEnumerable<FactoryDTO> GetAllFactory();
		ResponseModel<IEnumerable<Factory>> GetFactoryList();
	}
}
