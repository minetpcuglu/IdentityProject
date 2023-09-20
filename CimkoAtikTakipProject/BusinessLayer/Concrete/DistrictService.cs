using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer.DTO;
using EntitiesLayer;
using CoreLayer.DataAccess.EntityFramework;

namespace BusinessLayer.Concrete
{
	public class DistrictService : BaseService<District>, IDistrictService
	{
		private readonly IDistrictRepository _districtRepository;

		public DistrictService(IDistrictRepository districtRepository) : base(districtRepository)
		{
			_districtRepository = districtRepository;

		}

		public IEnumerable<DistrictDTO> GetAllDistrict()
		{
			var city = _districtRepository.GetQueryable().Where(x => x.SilinmeZamani == null && x.Aktif == true)
					.Select(c => new DistrictDTO
					{
						Id = c.Id,
						Name = c.Name,
						CityName=c.City.Name,
						Aktif = c.Aktif
					}).ToList();

			return city;
		}

		public ResponseModel<IEnumerable<District>> GetDistrictList()
		{
			return _districtRepository.ListAll();
		}
	}
}
