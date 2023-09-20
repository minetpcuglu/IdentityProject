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
	public class WasteCodeService : BaseService<WasteCode>, IWasteCodeService
	{
		private readonly IWasteCodeRepository _wasteCodeRepository;

		public WasteCodeService(IWasteCodeRepository wasteCodeRepository) : base(wasteCodeRepository)
		{
			_wasteCodeRepository = wasteCodeRepository;

		}

		public IEnumerable<WasteCodeDTO> GetAllWasteCode()
		{
			var city = _wasteCodeRepository.GetQueryable().Where(x => x.SilinmeZamani == null && x.Aktif == true)
					.Select(c => new WasteCodeDTO
					{
						Id = c.Id,
						Name = c.Name,
						Aktif = c.Aktif
					}).ToList();

			return city;
		}

		public ResponseModel<IEnumerable<WasteCode>> GetWasteCodeList()
		{
			return _wasteCodeRepository.ListAll();
		}
	}
}
