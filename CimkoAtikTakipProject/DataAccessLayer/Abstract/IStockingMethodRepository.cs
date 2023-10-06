﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.DataAccess.Abstract;
using EntitiesLayer;

namespace DataAccessLayer.Abstract
{
	public interface IStockingMethodRepository : IRepository<StockingMethod>
	{

		IEnumerable<StockingMethod> StockingMethodList();


	}
}