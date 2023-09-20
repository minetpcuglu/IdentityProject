using BusinessLayer.Abstract;
using CimkoAtikTakipProjectUI.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntitiesLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CimkoAtikTakipProjectUI.Controllers
{
	public class CityController : Controller
	{
		private readonly ICityService _cityService;
		public CityController(ICityService CityService)
		{
			_cityService = CityService;
		}
		/// <summary>
		/// Cityler Ekranı
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			return View();
		}


		/// <summary>
		///City Listeleme Durum ve Aktif = true
		/// </summary>
		/// <param name="loadOptions"></param>
		/// <returns></returns>
		[HttpGet]
		public object IndexGridData(DataSourceLoadOptions loadOptions)
		{
			var CityModel = new CityViewModel();
			CityModel.CityListe = _cityService.GetAllCity().ToList();
			return DataSourceLoader.Load(CityModel.CityListe, loadOptions);
		}

		/// <summary>
		/// City Silme Durum ve Aktif Bool=False and Silinme Zamanı = Datetime.Now 
		/// </summary>
		/// <param name="Key"></param>
		/// <returns></returns>

		[HttpDelete]
		public IActionResult Delete(int Key)
		{
			var deleteCity = _cityService.GetById(Key);
			_cityService.Delete(deleteCity, true);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// City Güncelleme Güncelleme Zamanı = Datetime.Now 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		[HttpPut]
		public ActionResult Edit(int key, string values)
		{
			var updateCity = _cityService.GetById(key);
			JsonConvert.PopulateObject(values, updateCity);
			_cityService.Update(updateCity, true);

			return RedirectToAction("Index");
		}


		/// <summary>
		/// City Ekleme Durum ve Aktif Bool=True and Eklenme Zamanı = Datetime.Now 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>

		[HttpPost]
		public IActionResult Post(string values)
		{
			var newCity = new City();
			JsonConvert.PopulateObject(values, newCity);
			_cityService.Insert(newCity, true);

			return RedirectToAction("Index");
		}
	}
}
