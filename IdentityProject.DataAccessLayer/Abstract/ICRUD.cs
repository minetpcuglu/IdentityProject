using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace IdentityProject.DataAccessLayer.Abstract
{
    public interface ICrud<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByGuidAsync(Guid guid);
        Task<int> CreateAsync(T dto);
        //Task DeleteAsync(int id);
        Task DeleteAsync(int id);
        Task<int> UpdateAsync(T dto);
    }
}
