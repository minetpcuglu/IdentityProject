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
	public interface IDistrictService : IBaseService<District>
	{
		public IEnumerable<DistrictDTO> GetAllDistrict();
		ResponseModel<IEnumerable<District>> GetDistrictList();
	}
}
