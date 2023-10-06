using System.ComponentModel.DataAnnotations;
using EntitiesLayer;
using EntitiesLayer.DTO;
using EntitiesLayer.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CimkoAtikTakipProjectUI.Models
{
	public class WasteFormViewModel
	{
		[Required(ErrorMessage = "Firma İsmi boş bırakılamaz.")]
		public string CompanyName { get; set; }

		/// <summary>
		/// E Posta
		/// </summary>


		[Required(ErrorMessage = "Email Adresi boş bırakılamaz.")]
		[EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz. ")]
		public string SendEmail { get; set; }

		/// <summary>
		/// Telefon num
		/// </summary>

		[Required(ErrorMessage = "Telefon Numarası boş bırakılamaz.")]
		[RegularExpression(@"^\d{4}\d{3}\d{4}$", ErrorMessage = "Geçerli bir telefon numarası formatı giriniz. Örnek: 0505 *** 7890")]
		public string Phone { get; set; }

		/// <summary>
		/// Aylık Miktar
		/// </summary>
		[Required(ErrorMessage = "Aylık Miktar boş bırakılamaz.")]
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
		[Required(ErrorMessage = "Lütfen Atık Kodu seçiniz")]
		public int? WasteCodeId { get; set; }

		/// <summary>
		/// Açık Adres
		/// </summary>
		[Required(ErrorMessage = "Acık Adres boş bırakılamaz.")]
		public string AddressLine { get; set; }

		/// <summary>
		/// İlçe
		/// </summary>
		/// 

		public District District { get; set; }
		public string DistrictName { get; set; }
		[Required(ErrorMessage = "Lütfen İlçe seçiniz")]
		public int? DistrictId { get; set; }


		public EntitiesLayer.City City { get; set; }
		[Required(ErrorMessage = "Lütfen Şehir seçiniz")]
		public int? CityId { get; set; }

		/// <summary>
		/// Fabrika
		/// </summary>

		public Factory Factory { get; set; }
		public string FactoryName { get; set; }
		[Required(ErrorMessage = "Lütfen Fabrika seçiniz")]
		public int? FactoryId { get; set; }


		/// <summary>
		/// Stoklama Yöntemi
		/// </summary>
		public StockingMethod StockingMethod { get; set; }

		[Required(ErrorMessage = "Lütfen Stoklama Yöntemi seçiniz")]
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
