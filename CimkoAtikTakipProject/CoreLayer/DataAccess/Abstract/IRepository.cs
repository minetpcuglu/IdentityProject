using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.EntityFramework;
using CoreLayer.Entities;

namespace CoreLayer.DataAccess.Abstract
{
	public interface IRepository<T> where T : IBaseEntity
	{
		ResponseModel<T> GetById(int id);
		ResponseModel<IEnumerable<T>> ListAll();
		IEnumerable<T> ListAlltek();
		ResponseModel<IEnumerable<T>> ListAllSilinme();
		IQueryable<T> GetQueryable();
		ResponseModel<T> Add(T entity, bool saveChanges = true);
		ResponseModel<T> Update(T entity, bool saveChanges = true);
		ResponseModel<bool> Delete(T entity, bool saveChanges = true);
		ResponseModel<int> Count(Expression<Func<T, bool>> where = null);

		ResponseModel<IEnumerable<T>> Where(Expression<Func<T, bool>> where = null,
			Expression<Func<T, object>> include = null);
		int SaveChanges();

	}
}
