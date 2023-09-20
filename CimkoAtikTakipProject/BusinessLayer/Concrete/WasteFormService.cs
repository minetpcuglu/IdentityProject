using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer.DTO;
using EntitiesLayer;
using DataAccessLayer.Repository;
using System.Numerics;
using EntitiesLayer.Enums;

namespace BusinessLayer.Concrete
{
	public class WasteFormService : BaseService<WasteForm>, IWasteFormService
	{
		private readonly IWasteFormRepository _wasteFormRepository;

		public WasteFormService(IWasteFormRepository wasteFormRepository) : base(wasteFormRepository)
		{
			_wasteFormRepository = wasteFormRepository;

		}

		public IEnumerable<WasteFormDTO> GetAllWasteForm()
		{
			var city = _wasteFormRepository.GetQueryable().Where(x => x.SilinmeZamani == null && x.Aktif == true)
					.Select(c => new WasteFormDTO
					{
						Id = c.Id,
						CompanyName = c.CompanyName,
						SendEmail=c.SendEmail,
						Phone=c.Phone,
						MonthlyAmount=c.MonthlyAmount,
						StockingMethodEnum=c.StockingMethodEnum,
						AddressLine=c.AddressLine,
						Description=c.Description,
						SendMailIsSuccess=c.SendMailIsSuccess,
						Aktif = c.Aktif,
						DistrictName=c.District.Name,
						WasteCodeName=c.WasteCode.Name,
					}).ToList();

			return city;
		}
	}
}
