using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
	public interface IBaseEntity
	{
		int Id { get; set; }
		public DateTime? GuncellenmeZamani { get; set; }
		public DateTime? SilinmeZamani { get; set; }
		public bool Aktif { get; set; }
	}
}
