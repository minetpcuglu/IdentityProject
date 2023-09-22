using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EntitiesLayer.Enums;
using CoreLayer.Entities;

namespace EntitiesLayer
{
	/// <summary>
	/// Atık Form
	/// </summary>
	public class WasteForm:BaseEntity
	{
		/// <summary>
		/// Atık Üreticisi Tesis Adı
		/// </summary>

		[Required]
		[StringLength(500)]
		public string CompanyName { get; set; }

		/// <summary>
		/// E Posta
		/// </summary>

		[Required]
		[StringLength(100)]
		public string SendEmail { get; set; }

		/// <summary>
		/// Telefon num
		/// </summary>
		[Required]
		[StringLength(50)]
		public string? Phone { get; set; }

		/// <summary>
		/// Aylık Miktar
		/// </summary>

		[Required]
		[StringLength(50)]
		public string MonthlyAmount { get; set; }

		///// <summary>
		///// Stoklama yöntemi
		///// </summary>
		//public StockingMethodEnum? StockingMethodEnum { get; set; }

		/// <summary>
		/// Atık Kodu
		/// </summary>
		public WasteCode WasteCode { get; set; }
		public int WasteCodeId { get; set; }

		/// <summary>
		/// Açık Adres
		/// </summary>

		[Required]
		[StringLength(500)]
		public string AddressLine { get; set; }

		/// <summary>
		/// İlçe
		/// </summary>
		public District District { get; set; }
		public int DistrictId { get; set; }

		/// <summary>
		/// İlçe
		/// </summary>
		public Factory Factory { get; set; }
		public int FactoryId { get; set; }

		/// <summary>
		/// Stoklama Yöntemi
		/// </summary>
		public StockingMethod StockingMethod { get; set; }
		public int StockingMethodId { get; set; }

		/// <summary>
		/// Görüş ve İletiler
		/// </summary>
		[StringLength(500)]
		public string? Description { get; set; }

		/// <summary>
		/// Mail Gönderildi mi?
		/// </summary>
		public bool? SendMailIsSuccess { get; set; }

		public ICollection<WasteFormImage> WasteFormImage { get; set; }

	}
}
