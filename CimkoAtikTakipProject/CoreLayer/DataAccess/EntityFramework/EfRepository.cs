using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.Abstract;
using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CoreLayer.DataAccess.EntityFramework
{
	public class EfRepository<T> : IRepository<T> where T : class, IBaseEntity
	{
		protected readonly DbContext context;
		protected readonly IHttpContextAccessor _httpContextAccessor;
		public EfRepository(DbContext dbContext, IHttpContextAccessor httpContextAccessor)
		{
			context = dbContext;
			_httpContextAccessor = httpContextAccessor;
		}

		public virtual ResponseModel<T> GetById(int id)
		{
			ResponseModel<T> response = new ResponseModel<T>();
			try
			{

				response.Data = context.Set<T>().FirstOrDefault(c => c.Id == id);
				response.isSucceeded = response.Data != null;
			}
			catch (Exception e)
			{
				response.Exception = e;
			}

			return response;
		}

		public ResponseModel<IEnumerable<T>> ListAll()
		{

			ResponseModel<IEnumerable<T>> response = new ResponseModel<IEnumerable<T>>();

			try
			{
				// Aktif olanları ve silinme zamanı null olanları LINQ sorgusu ile filtreleyin.
				var activeAndNotDeletedItems = context.Set<T>().Where(item => item.Aktif && item.SilinmeZamani == null).ToList();

				response.Data = activeAndNotDeletedItems;
				response.isSucceeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				response.isSucceeded = false;
			}

			return response;

		}

		public IEnumerable<T> ListAlltek()
		{

			// Aktif olanları ve silinme zamanı null olanları LINQ sorgusu ile filtreleyin.
			var activeAndNotDeletedItems = context.Set<T>().Where(item => item.Aktif && item.SilinmeZamani == null).ToList();

			return activeAndNotDeletedItems;
		}

		public ResponseModel<IEnumerable<T>> ListAllSilinme()
		{
			ResponseModel<IEnumerable<T>> response = new ResponseModel<IEnumerable<T>>();

			try
			{
				// Aktif olanları ve silinme zamanı null olanları LINQ sorgusu ile filtreleyin.
				var activeAndNotDeletedItems = context.Set<T>();

				response.Data = activeAndNotDeletedItems;
				response.isSucceeded = true;
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				response.isSucceeded = false;
			}

			return response;
		}




		public ResponseModel<T> Add(T entity, bool saveChanges = true)
		{
			var response = new ResponseModel<T>();

			try
			{
				context.Set<T>().Add(entity);
				response.Data = entity;
				var validationResults = context.CheckValidation();
				if (validationResults != null)
				{
					context.Set<T>().Remove(entity);
					response.isSucceeded = false;
					response.ValidationResults = validationResults;
				}
				else
				{
					if (saveChanges)
						SaveChanges();
					response.isSucceeded = response.Data != null;
				}

			}
			catch (Exception e)
			{
				context.Set<T>().Remove(entity);
				response.isSucceeded = false;
				response.Exception = e;
			}
			return response;
		}


		public ResponseModel<T> Update(T entity, bool saveChanges = true)
		{
			bool isDetached = context.Entry(entity).State == EntityState.Detached;
			if (isDetached)
				context.Set<T>().Attach(entity);

			var response = new ResponseModel<T>();

			try
			{
				var validationResults = context.CheckValidation();

				if (validationResults != null)
				{
					response.isSucceeded = false;
					response.ValidationResults = validationResults;
				}
				else
				{
					// "UpdateTime" özelliğini güncel tarih ve saat ile ayarlayın
					var updateTimeProperty = entity.GetType().GetProperty("GuncellenmeZamani");
					if (updateTimeProperty != null && updateTimeProperty.PropertyType == typeof(DateTime?))
					{
						updateTimeProperty.SetValue(entity, DateTime.Now);
					}

					context.Set<T>().Update(entity);

					if (saveChanges)
						SaveChanges();

					response.isSucceeded = response.Data != null;
				}
			}
			catch (Exception e)
			{
				context.Set<T>().Remove(entity);
				response.isSucceeded = false;
				response.Exception = e;
			}

			return response;
		}


		public ResponseModel<bool> Delete(T entity, bool saveChanges = true)
		{
			bool isDetached = context.Entry(entity).State == EntityState.Detached;
			if (isDetached)
				context.Set<T>().Attach(entity);

			var response = new ResponseModel<bool>();

			try
			{
				var validationResults = context.CheckValidation();

				if (validationResults != null)
				{
					response.isSucceeded = false;
					response.ValidationResults = validationResults;
				}
				else
				{
					// "SilmeZamani" özelliğini DateTime.Now ile güncelleme
					var deleteTimeProperty = entity.GetType().GetProperty("SilinmeZamani");
					if (deleteTimeProperty != null && deleteTimeProperty.PropertyType == typeof(DateTime?))
					{
						deleteTimeProperty.SetValue(entity, DateTime.Now);
					}

					// "Aktif" adlı bool alanını false olarak ayarlama (pasif hale getirme)
					var activeProperty = entity.GetType().GetProperty("Aktif");
		
					if (activeProperty != null && activeProperty.PropertyType == typeof(bool))
					{
						activeProperty.SetValue(entity, false);
						
					}
					context.Set<T>().Update(entity);

					if (saveChanges)
						SaveChanges();

					response.Data = true;
					response.isSucceeded = true;
				}
			}
			catch (Exception e)
			{
				context.Set<T>().Remove(entity);
				response.isSucceeded = false;
				response.Exception = e;
				throw new InvalidOperationException("İlşikili olan tablolarda kayıt silinme durumunu sistem yoneticileri ile iletisime gecin ");

			}

			return response;
		}

	
		public ResponseModel<int> Count(Expression<Func<T, bool>> where = null)
		{
			//BaseSpecification<T>  spec = new BaseSpecification<T>()
			//{
			//    Criteria = where
			//};
			//return Count(spec);
			return Count();
		}
		public ResponseModel<IEnumerable<T>> Where(Expression<Func<T, bool>> where = null, Expression<Func<T, object>> include = null)
		{
			var data = context.Set<T>().Where(where);
			if (include != null)
				data = data.Include(include);
			var response = new ResponseModel<IEnumerable<T>>();
			response.Data = data;
			response.isSucceeded = true;
			return response;
		}
		public IQueryable<T> GetQueryable()
		{
			return context.Set<T>();
		}


		public int SaveChanges()
		{
			return context.SaveChanges();
		}

	}

	public enum DbIslemTip
	{
		Insert,
		Update,
		Delete
	}
}
