using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProject.BusinessLayer.CustomerAccount
{
    public class CustomerAccountRequest
    {
        public string Number { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string BankBranch { get; set; }
        public int AppUserID { get; set; }
        public bool Aktif { get; set; }

        public DateTime EklenmeZamani { get; set; }
    }
}
