using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;

namespace CoreLayer.DataAccess.Abstract
{
	public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
	{
		TEntity Get(int id);
		IQueryable<TEntity> GetAll();
		IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		void Add(TEntity entity);
		void Delete(TEntity entity);
		void Edit(TEntity entity);
		void Save();

	}
}
