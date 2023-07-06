using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IdentityProject.BusinessLayer.CustomerAccount
{
    public interface ICustomerAccountService
    {
        Task<List<DTOLayer.DTOs.CustomerAccountDto.CustomerAccountDto>> GetCustomerAccountListAsync();
        Task GetByGuid(Guid customerAccount);
        Task GetById(int customerAccountId);
        Task<bool> AddCustomerAccountAsync(CustomerAccountRequest request);
        Task UpdateCustomerAccountAsync(Guid customerAccountId, CustomerAccountRequest request);
        Task DeleteCustomerAccountAsync(Guid customerAccountGuid);
    }
}
