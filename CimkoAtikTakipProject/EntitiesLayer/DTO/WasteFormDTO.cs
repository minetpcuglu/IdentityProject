using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.Enums;

namespace EntitiesLayer.DTO
{
	public class WasteFormDTO : BaseEntityDTO
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

		/// <summary>
		/// Stoklama yöntemi
		/// </summary>
		public StockingMethodEnum? StockingMethodEnum { get; set; }
		public string StockingMethodEnumString => StockingMethodEnum.GetDisplayValue();

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


		/// <summary>
		/// Görüş ve İletiler
		/// </summary>

		public string? Description { get; set; }

		/// <summary>
		/// Mail Gönderildi mi?
		/// </summary>
		public bool? SendMailIsSuccess { get; set; }

		public ICollection<WasteFormImage> WasteFormImage { get; set; }
	}
}
