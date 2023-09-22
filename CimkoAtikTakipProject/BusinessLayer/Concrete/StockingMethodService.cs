using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer.DTO;
using EntitiesLayer;

namespace BusinessLayer.Concrete
{
	public class StockingMethodService : BaseService<StockingMethod>, IStockingMethodService
	{
		private readonly IStockingMethodRepository _stockingMethodRepository;

		public StockingMethodService(IStockingMethodRepository stockingMethodRepository) : base(stockingMethodRepository)
		{
			_stockingMethodRepository = stockingMethodRepository;

		}

		public IEnumerable<StockingMethodDTO> GetAllStockingMethod()
		{

			var city = _stockingMethodRepository.GetQueryable().Where(x => x.SilinmeZamani == null && x.Aktif == true)
				.Select(c => new StockingMethodDTO
				{
					Id = c.Id,
					Name = c.Name,
					Aktif = c.Aktif
				}).ToList();

			return city;
		}
	}
}
