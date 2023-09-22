using EntitiesLayer;
using EntitiesLayer.DTO;
using EntitiesLayer.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CimkoAtikTakipProjectUI.Models
{
	public class WasteFormViewModel
	{

		public string CompanyName { get; set; }

		/// <summary>
		/// E Posta
		/// </summary>
		public string SendEmail { get; set; }

		/// <summary>
		/// Telefon num
		/// </summary>

		public string? Phone { get; set; }

		/// <summary>
		/// Aylık Miktar
		/// </summary>

		public string MonthlyAmount { get; set; }

		///// <summary>
		///// Stoklama yöntemi
		///// </summary>
		//public StockingMethodEnum? StockingMethodEnum { get; set; }
		//public string StockingMethodEnumString => StockingMethodEnum.GetDisplayValue();
		//public List<SelectListItem> StockingMethodEnumList { get; set; }

		/// <summary>
		/// Atık Kodu
		/// </summary>
		public WasteCode WasteCode { get; set; }
		public string WasteCodeName { get; set; }
		public int? WasteCodeId { get; set; }

		/// <summary>
		/// Açık Adres
		/// </summary>

		public string AddressLine { get; set; }

		/// <summary>
		/// İlçe
		/// </summary>
		public District District { get; set; }
		public string DistrictName { get; set; }
		public int? DistrictId { get; set; }

		public EntitiesLayer.City City { get; set; }
		public int? CityId { get; set; }

		/// <summary>
		/// Fabrika
		/// </summary>
		public Factory Factory { get; set; }
		public string FactoryName { get; set; }
		public int? FactoryId { get; set; }


		/// <summary>
		/// Stoklama Yöntemi
		/// </summary>
		public StockingMethod StockingMethod { get; set; }
		public int? StockingMethodId { get; set; }

		/// <summary>
		/// Görüş ve İletiler
		/// </summary>

		public string? Description { get; set; }

		/// <summary>
		/// Mail Gönderildi mi?
		/// </summary>
		public bool? SendMailIsSuccess { get; set; }
		public IEnumerable<SelectListItem> DistrictList { get; set; }
		public IEnumerable<SelectListItem> WasteCodeList { get; set; }
		public List<WasteFormDTO> WasteFormListe { get; set; }
		public List<SelectListItem> WasteFormList { get; set; }
	}
}
