using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.EntityLayer.Infrastructure
{
    public abstract class Base
    {
        [NotMapped]
        public EntityState EntityState { get; set; }

        [Key]
        public int Id { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool Aktif { get; set; } = true;
        public Guid? Silindi { get; set; }
        public DateTime EklenmeZamani { get; set; } = DateTime.Now;
        public DateTime? GuncellenmeZamani { get; set; }
        public DateTime? SilinmeZamani { get; set; }

    }
}
