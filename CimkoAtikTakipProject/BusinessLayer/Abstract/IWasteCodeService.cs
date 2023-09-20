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
	public interface IWasteCodeService : IBaseService<WasteCode>
	{
		public IEnumerable<WasteCodeDTO> GetAllWasteCode();
		ResponseModel<IEnumerable<WasteCode>> GetWasteCodeList();
	}
}
