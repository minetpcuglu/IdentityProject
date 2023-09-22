using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntitiesLayer.DTO;
using EntitiesLayer;

namespace BusinessLayer.Concrete
{
	public class FactoryService : BaseService<Factory>, IFactoryService
	{
		private readonly IFactoryRepository _factoryRepository;

		public FactoryService(IFactoryRepository factoryRepository) : base(factoryRepository)
		{
			_factoryRepository = factoryRepository;

		}

		public IEnumerable<FactoryDTO> GetAllFactory()
		{
		
				var city = _factoryRepository.GetQueryable().Where(x => x.SilinmeZamani == null && x.Aktif == true)
					.Select(c => new FactoryDTO
					{
						Id = c.Id,
						Name = c.Name,
						Aktif = c.Aktif
					}).ToList();

			return city;
		}

		public ResponseModel<IEnumerable<Factory>> GetFactoryList()
		{
			return _factoryRepository.ListAll();
		}
	}
}
