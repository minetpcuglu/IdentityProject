using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;
using EntitiesLayer.Enums;

namespace EntitiesLayer
{
	public class WasteFormImage:BaseEntity
	{
        public int WasteFormId { get; set; }
        public WasteForm WasteForm { get; set; }
        public string Base64 { get; set; }

		/// <summary>
		/// Form Durum 
		/// </summary>
		public WasteFormStatusEnum? WasteFormStatusEnum { get; set; }
	}
}
