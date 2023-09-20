using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Enums
{
	
	public enum StockingMethodEnum : byte
	{
		[Display("Çuval")]
		Cuval = 0,
		[Display("Varil")]
		Varil = 1,
		[Display("İbc")]
		Ibc = 2,
		[Display("Dökme")]
		Dokme = 3
	}
	public class DisplayAttribute : Attribute
	{
		public string Value { get; }

		public DisplayAttribute(string value)
		{
			Value = value;
		}
	}

	public static class EnumExtensions
	{
		public static string GetDisplayValue(this Enum value)
		{
			var fieldInfo = value.GetType().GetField(value.ToString());
			var displayAttribute = fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
			return displayAttribute?.Length > 0 ? displayAttribute[0].Value : value.ToString();
		}
	}
}
