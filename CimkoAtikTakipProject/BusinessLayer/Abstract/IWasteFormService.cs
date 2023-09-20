using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.DTO;
using EntitiesLayer;

namespace BusinessLayer.Abstract
{
	public interface IWasteFormService : IBaseService<WasteForm>
	{
		public IEnumerable<WasteFormDTO> GetAllWasteForm();
	}
}
