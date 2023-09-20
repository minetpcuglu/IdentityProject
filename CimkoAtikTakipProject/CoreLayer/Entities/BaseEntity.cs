using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
	public class BaseEntity : IBaseEntity, IEquatable<BaseEntity>
	{
		public int Id { get; set; }
		public bool Aktif { get; set; } = true;
		public DateTime EklenmeZamani { get; set; } = DateTime.Now;
		public DateTime? GuncellenmeZamani { get; set; }
		public DateTime? SilinmeZamani { get; set; }


		//public long EkleyenKullaniciId { get; set; }

		//public long KullaniciId { get; set; }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((BaseEntity)obj);
		}

		public bool Equals(BaseEntity other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Id == other.Id;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

	}
}
