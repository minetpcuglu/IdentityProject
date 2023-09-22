using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.EntityFramework;
using CoreLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
	public class BaseService<T> : IBaseService<T> where T : IBaseEntity
	{
		private readonly IRepository<T> _baseRepository;
		private readonly IHttpContextAccessor _context;


		public BaseService(IRepository<T> baseRepository)
		{
			_baseRepository = baseRepository;

		}
		#region Insert
		public virtual ResponseModel<T> Insert(T entity, bool save = false)
		{
			//var userDetail = _kullaniciService.GetCurrentUserDetail();
			//userDetail.Data.Id = entity.EkleyenKullaniciId;

			return _baseRepository.Add(entity, save);
		}
		#endregion

		#region Update
		public virtual ResponseModel<T> Update(T entity, bool save = false)
		{
			return _baseRepository.Update(entity, save);
		}
		#endregion

		#region Delete
		public virtual ResponseModel<bool> Delete(T entity, bool save = false)
		{
			return _baseRepository.Delete(entity, save);
		}
		#endregion

	

		#region ListAll
		public virtual ResponseModel<IEnumerable<T>> ListAll()
		{
			return _baseRepository.ListAll();
		}
		#endregion

		#region FindById
		public virtual ResponseModel<T> FindById(int? id)
		{
			return _baseRepository.GetById((int)id);
		}
		#endregion


		#region SaveChanges
		public virtual int SaveChanges()
		{
			return _baseRepository.SaveChanges();
		}
		#endregion

		public T GetById(int? Id)
		{
			var oldEntity = _baseRepository.GetQueryable()
				.FirstOrDefault(k => k.Id == Id);
			return oldEntity;
		}


	}
}
