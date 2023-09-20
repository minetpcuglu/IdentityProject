using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
	public class BaseEntityDTO
	{
		public long Id { get; set; }
		public bool Aktif { get; set; } = true;
		public Guid? Silindi { get; set; }
		public DateTime EklenmeZamani { get; set; } = DateTime.Now;
		public DateTime? GuncellenmeZamani { get; set; }
		public DateTime? SilinmeZamani { get; set; }
	}
}
