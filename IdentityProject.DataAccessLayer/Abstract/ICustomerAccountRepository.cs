using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.DTOLayer.DTOs.CustomerAccountDto;
using IdentityProject.EntityLayer.Concrete;

namespace IdentityProject.DataAccessLayer.Abstract
{
    public  interface  ICustomerAccountRepository : ICrud<CustomerAccountDto>
    {
        Task<List<CustomerAccountDto>> GetCustomerAccountListAsync();
    }
}
