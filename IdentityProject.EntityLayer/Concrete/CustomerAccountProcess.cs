using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.EntityLayer.Infrastructure;

namespace IdentityProject.EntityLayer.Concrete
{
    [Table("CustomerAccountProcess")]
    public class CustomerAccountProcess:Base
    {
        public int CustomerAccountProcessID { get; set; }
        public string ProcessType { get; set; }
        public decimal Amount{ get; set; }
        public int ProcessDate { get; set; }
    }
}
