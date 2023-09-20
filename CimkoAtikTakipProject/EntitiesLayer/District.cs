using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;

namespace EntitiesLayer
{
	/// <summary>
	/// İlçe
	/// </summary>
	public class District:BaseEntity
	{
        public string Name { get; set; }
        public City City { get; set; }
		public int CityId { get; set; }
		public ICollection<WasteForm> WasteForm { get; set; }
	}
}
