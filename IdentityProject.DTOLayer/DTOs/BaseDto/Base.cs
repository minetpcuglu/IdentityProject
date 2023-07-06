using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProject.DTOLayer.DTOs.BaseDto
{
    public class Base
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool Aktif { get; set; }
        public Guid? Silindi { get; set; }
        public DateTime EklenmeZamani { get; set; }
        public DateTime? GuncellenmeZamani { get; set; }
        public DateTime? SilinmeZamani { get; set; }
    }
}
