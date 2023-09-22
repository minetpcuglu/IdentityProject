using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Enums
{

	public enum WasteFormStatusEnum : byte
	{
		[Display("Form Onaylandı")]
		FormOnaylandi = 0,
		[Display("Numune Gönderildi")]
		NumuneGonderildi = 1,
		[Display("Takip Numarası")]
		TakipNumarasi = 2,
		[Display("Form Gönderildi")]
		formGonderildi = 3,

	}
	public class DisplayAttributeWasteForm : Attribute
	{
		public string Value { get; }

		public DisplayAttributeWasteForm(string value)
		{
			Value = value;
		}
	}

	public static class EnumExtensionsWasteForm
	{
		public static string GetDisplayValueWasteForm(this Enum value)
		{
			var fieldInfo = value.GetType().GetField(value.ToString());
			var displayAttribute = fieldInfo?.GetCustomAttributes(typeof(DisplayAttributeWasteForm), false) as DisplayAttributeWasteForm[];
			return displayAttribute?.Length > 0 ? displayAttribute[0].Value : value.ToString();
		}
	}
}
