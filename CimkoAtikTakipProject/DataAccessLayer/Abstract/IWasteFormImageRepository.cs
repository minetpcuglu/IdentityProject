using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.Abstract;
using EntitiesLayer;

namespace DataAccessLayer.Abstract
{
	public interface IWasteFormImageRepository : IRepository<WasteFormImage>
	{

		IEnumerable<WasteFormImage> WasteFormImageList();


	}
}
