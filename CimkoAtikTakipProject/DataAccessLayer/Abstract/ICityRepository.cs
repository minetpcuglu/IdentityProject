using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.EntityFramework;
using EntitiesLayer;

namespace DataAccessLayer.Abstract
{
	public interface ICityRepository : IRepository<City>
	{

		IEnumerable<City> CityList();


	}
}
