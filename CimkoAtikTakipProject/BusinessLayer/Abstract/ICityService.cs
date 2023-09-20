using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using EntitiesLayer.DTO;

namespace BusinessLayer.Abstract
{
	public interface ICityService : IBaseService<City>
	{
		public IEnumerable<CityDTO> GetAllCity();
	}
}
