using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.Enums;

namespace EntitiesLayer.DTO
{
	public class WasteFormImageDTO:BaseEntityDTO
	{
		public int WasteFormId { get; set; }
		public WasteFormDTO WasteForm { get; set; }
		public string Base64 { get; set; }

		/// <summary>
		/// Form Durum 
		/// </summary>
		public WasteFormStatusEnum? WasteFormStatusEnum { get; set; }
		public string WasteFormStatusEnumString => WasteFormStatusEnum.GetDisplayValueWasteForm();
	}
}
