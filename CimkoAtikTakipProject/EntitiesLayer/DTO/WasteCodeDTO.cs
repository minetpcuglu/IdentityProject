using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
	public class WasteCodeDTO : BaseEntityDTO
	{
		public string Name { get; set; }
		public string? Description { get; set; }

		public ICollection<WasteForm> WasteForm { get; set; }
	}
}
