using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.EntityLayer.Infrastructure;

namespace IdentityProject.EntityLayer.Concrete
{
    [Table("CustomerAccount")]
    public class CustomerAccount : Base
    {
        public string Number { get; set; }
        public string Currency { get; set; }
        public decimal  Balance { get; set; }
        public string BankBranch { get; set; }
    }
}
