using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.DTO;

namespace BusinessLayer.Concrete
{
	public class CityService : BaseService<City>, ICityService
	{
		private readonly ICityRepository _cityRepository;

		public CityService(ICityRepository cityRepository) : base(cityRepository)
		{
			_cityRepository = cityRepository;

		}

		public IEnumerable<CityDTO> GetAllCity()
		{
			var city = _cityRepository.GetQueryable().Where(x => x.SilinmeZamani == null && x.Aktif == true)
					.Select(c => new CityDTO
					{
						Id = c.Id,
						Name = c.Name,
						Aktif = c.Aktif
					}).ToList();

			return city;
		}
	}
}
