using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.DataAccessLayer.Abstract;
using IdentityProject.DTOLayer.DTOs.CustomerAccountDto;

namespace IdentityProject.BusinessLayer.CustomerAccount
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly ICustomerAccountRepository _customerAccountRepository;

        public CustomerAccountService(ICustomerAccountRepository customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        public async Task<bool> AddCustomerAccountAsync(CustomerAccountRequest request)
        {
            var customerAccountDto = new CustomerAccountDto()
            {
                Number = request.Number,
                Balance = request.Balance,
                Currency = request.Currency,
                BankBranch = request.BankBranch,
                Aktif = true,
                EklenmeZamani = DateTime.Now
            };
            
            var addId = await _customerAccountRepository.CreateAsync(customerAccountDto);
            if (addId <= 0) return false;

            customerAccountDto.Id = addId;
            return true;
        }

        public Task DeleteCustomerAccountAsync(Guid customerAccountGuid)
        {
            throw new NotImplementedException();
        }

        public Task GetByGuid(Guid customerAccount)
        {
            throw new NotImplementedException();
        }

        public Task GetById(int customerAccountId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerAccountDto>> GetCustomerAccountListAsync()
        {
            var list = await _customerAccountRepository.GetCustomerAccountListAsync();
            return new List<CustomerAccountDto>(list);
        }

        public Task UpdateCustomerAccountAsync(Guid customerAccountId, CustomerAccountRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
