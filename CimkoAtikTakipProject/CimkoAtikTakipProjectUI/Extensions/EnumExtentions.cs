using Microsoft.AspNetCore.Mvc.Rendering;

namespace CimkoAtikTakipProjectUI.Extensions
{
	public static class EnumExtentions
	{
		public static int Value(this Enum gelenDeger)
		{
			return Convert.ToInt16(gelenDeger);
		}
	}

	public static class IEnumExtention
	{
		public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<SelectListItem> list, string ilkKayitBaslik = "Tümü")
		{
			var tempList = list.ToList();
			tempList.Insert(0, (new SelectListItem
			{
				Text = ilkKayitBaslik,
				Value = "0"
			}));
			return tempList;
		}
	}
}
