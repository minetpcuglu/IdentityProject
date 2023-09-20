using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.Abstract;
using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.DataAccess.EntityFramework
{
	public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
	{
		protected readonly DbContext context;


		public EfGenericRepository(DbContext context)
		{
			this.context = context;

		}

		public void Add(TEntity entity)
		{
			context.Set<TEntity>().Add(entity);
		}

		public void Delete(TEntity entity)
		{
			context.Set<TEntity>().Remove(entity);
		}

		public void Edit(TEntity entity)
		{
			context.Entry(entity).State = EntityState.Modified;
		}

		public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return context.Set<TEntity>().Where(predicate);
		}

		public TEntity Get(int id)
		{
			return context.Set<TEntity>().Find(id);
		}

		public IQueryable<TEntity> GetAll()
		{

			return context.Set<TEntity>();
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
