using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityProject.DataAccessLayer.Abstract;
using IdentityProject.DataAccessLayer.DbContext;
using IdentityProject.DataAccessLayer.Mappings;
using IdentityProject.DTOLayer.DTOs.CustomerAccountDto;
using IdentityProject.EntityLayer.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentityProject.DataAccessLayer.Concrete
{
    public class CustomerAccountRepository : ICustomerAccountRepository
    {
        private readonly IRepository<CustomerAccount> _customerAccountRepository;
        private readonly DatabaseContext _context;

        public CustomerAccountRepository(IRepository<CustomerAccount> customerAccountRepository, DatabaseContext context)
        {
            _customerAccountRepository = customerAccountRepository;
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> CreateAsync(CustomerAccountDto dto)
        {
            var entity = ModelMapper.Mapper.Map<CustomerAccount>(dto);
            entity.EntityState = EntityState.Added;
            return await _customerAccountRepository.SaveAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _customerAccountRepository.GetFirstOrDefaultAsync(x => x.Id == id);
            entity.Silindi = Guid.NewGuid();
            entity.SilinmeZamani = DateTime.Now;
            entity.Aktif = false;
            entity.EntityState = EntityState.Modified;
            await _customerAccountRepository.SaveAsync(entity);
        }

        public async Task<CustomerAccountDto> GetByGuidAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerAccountDto> GetByIdAsync(int id)
        {
            var entity = await _customerAccountRepository.GetFirstOrDefaultAsync(u => u.Silindi == null &&  u.Id == id);
            return ModelMapper.Mapper.Map<CustomerAccountDto>(entity);
           
        }

        public async Task<int> UpdateAsync(CustomerAccountDto dto)
        {
            var entity = ModelMapper.Mapper.Map<CustomerAccount>(dto);
            entity.GuncellenmeZamani = DateTime.Now;
            entity.EntityState = EntityState.Modified;
            return await _customerAccountRepository.SaveAsync(entity);
        }

        public async Task<List<CustomerAccountDto>> GetCustomerAccountListAsync()
        {
            IQueryable<CustomerAccount> list = _context.CustomerAccounts.AsNoTracking().Where(x => x.Silindi == null).Include(x=>x.AppUser);

            var tmpContent = await list.OrderByDescending(x => x.EklenmeZamani).ThenBy(x => x.Number)
               .ToListAsync();
            var customerAccounts = ModelMapper.Mapper.Map<IList<CustomerAccountDto>>(tmpContent).ToList();
          
            return customerAccounts;
            //if (!string.IsNullOrEmpty(co.Adi))
            //{
            //    list = list.Where(x => Microsoft.EntityFrameworkCore.EF.Functions.Like(x.Adi, "%" + co.Adi + "%"));
            //}


            //if (!string.IsNullOrEmpty(co.Aciklama))
            //{
            //    list = list.Where(x => Microsoft.EntityFrameworkCore.EF.Functions.Like(x.Aciklama, "%" + co.Aciklama + "%"));
            //}
        }
    }
}
