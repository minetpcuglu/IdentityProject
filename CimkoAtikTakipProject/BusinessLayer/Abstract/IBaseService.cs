using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.EntityFramework;

namespace BusinessLayer.Abstract
{
	public interface IBaseService<T>
	{
		ResponseModel<T> Insert(T entity, bool save = false);
		ResponseModel<T> Update(T entity, bool save = false);
		ResponseModel<bool> Delete(T entity, bool save = false);
		ResponseModel<IEnumerable<T>> ListAll();
		ResponseModel<T> FindById(int? id);
		int SaveChanges();
		public T GetById(int Id);
	}
}
