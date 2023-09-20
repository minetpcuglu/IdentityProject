using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
	public class DistrictDTO:BaseEntityDTO
	{
		public string Name { get; set; }
		public string? CityName { get; set; }
		public CityDTO City { get; set; }
		public int? CityId { get; set; }
		public ICollection<WasteForm> WasteForm { get; set; }
	}
}
