using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntitiesLayer;
using EntitiesLayer.DTO;

namespace BusinessLayer.Concrete
{
	public class WasteFormImageService : BaseService<WasteFormImage>, IWasteFormImageService
	{
		private readonly IWasteFormImageRepository _wasteFormImageRepository;

		public WasteFormImageService(IWasteFormImageRepository wasteFormImageRepository) : base(wasteFormImageRepository)
		{
			_wasteFormImageRepository = wasteFormImageRepository;

		}

		public IEnumerable<WasteFormImageDTO> GetAllWasteFormImage()
		{
			var city = _wasteFormImageRepository.GetQueryable().Where(x => x.SilinmeZamani == null && x.Aktif == true)
					.Select(c => new WasteFormImageDTO
					{
						Id = c.Id,
						Base64=c.Base64,
						Aktif = c.Aktif,
						//WasteFormName = c.WasteForm.CompanyName,
					}).ToList();

			return city;
		}
	}
}
