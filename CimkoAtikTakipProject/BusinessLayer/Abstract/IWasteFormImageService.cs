using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.DTO;
using EntitiesLayer;

namespace BusinessLayer.Abstract
{
	public interface IWasteFormImageService : IBaseService<WasteFormImage>
	{
		public IEnumerable<WasteFormImageDTO> GetAllWasteFormImage();
	}
}
