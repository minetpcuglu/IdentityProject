using AutoMapper;
using BusinessLayer.Abstract;
using CimkoAtikTakipProjectUI.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntitiesLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CimkoAtikTakipProjectUI.Controllers
{
	public class WasteFormController : Controller
	{
		private readonly IWasteFormService _wasteFormService;
		private readonly IWasteCodeService _wasteCodeService;
		private readonly IDistrictService _districtService;
		private readonly ICityService _cityService;

		public WasteFormController(IWasteFormService wasteFormService,IDistrictService districtService,	ICityService cityService,IWasteCodeService wasteCodeService) 
		{
			_wasteFormService = wasteFormService;
			_districtService = districtService;
			_cityService = cityService;
			_wasteCodeService = wasteCodeService;
		}

		/// <summary>
		/// AtıkForm Ekranı
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{

			return View();
		}

		/// <summary>
		/// Atık Kod Dropdown Listeleme Atık FormTip Durum ve Aktif = true 
		/// </summary>
		/// <param name="loadOptions"></param>
		/// <returns></returns>
		[HttpGet]
		public object GetAllWasteCode(DataSourceLoadOptions loadOptions)
		{
			var WasteCodeList =  _wasteCodeService.GetWasteCodeList().Data; //null
			return DataSourceLoader.Load(WasteCodeList, loadOptions);
		}

		/// <summary>
		///Atık Form Listeleme Durum ve Aktif = true
		/// </summary>
		/// <param name="loadOptions"></param>
		/// <returns></returns>
		[HttpGet]
		public object IndexGridData(DataSourceLoadOptions loadOptions)
		{
			var atikFormModel = new WasteFormViewModel();
			atikFormModel.WasteFormListe = _wasteFormService.GetAllWasteForm().ToList();
			return DataSourceLoader.Load(atikFormModel.WasteFormListe, loadOptions);
		}

		/// <summary>
		/// Atık Form Silme Durum ve Aktif Bool=False and Silinme Zamanı = Datetime.Now 
		/// </summary>
		/// <param name="Key"></param>
		/// <returns></returns>

		[HttpDelete]
		public IActionResult Delete(int Key)
		{
			var deleteWasteForm = _wasteFormService.GetById(Key);
			_wasteFormService.Delete(deleteWasteForm, true);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Atık Form Güncelleme Güncelleme Zamanı = Datetime.Now 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		[HttpPut]
		public ActionResult Edit(int key, string values)
		{
			var updateAtıkForm = _wasteFormService.GetById(key);
			JsonConvert.PopulateObject(values, updateAtıkForm);
			_wasteFormService.Update(updateAtıkForm, true);

			return RedirectToAction("Index");
		}

		/// <summary>
		/// Atık Form Ekleme Durum ve Aktif Bool=True and Eklenme Zamanı = Datetime.Now 
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>

		[HttpPost]
		public IActionResult Post(string values)
		{
			var newAtıkForm = new WasteForm();
			JsonConvert.PopulateObject(values, newAtıkForm);
			_wasteFormService.Insert(newAtıkForm, true);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public object GetCities(DataSourceLoadOptions loadOptions)
		{
			var CityList = _cityService.GetAllCity();
			return DataSourceLoader.Load(CityList, loadOptions);
		}


		[HttpGet]
		public object GetAllDistrict(DataSourceLoadOptions loadOptions)
		{
			var DistrictList = _districtService.GetDistrictList().Data;
			return DataSourceLoader.Load(DistrictList, loadOptions);
		}

		[HttpGet]
        public IActionResult NewWasteForm()
        {
           
            var model = new WasteFormViewModel
            {

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult NewWasteForm(WasteFormViewModel cagriViewModel)
        {
            //var kullaniciMail = _httpContextAccessor.HttpContext?.User?.Identity.Name;
            //var _userID = _kullaniciService.GetByEmail(kullaniciMail).Id;
            //if (cagriViewModel.DestekGrupKullanicilar.DestekGrupId != null && cagriViewModel.DestekGrupKullanicilar.TeknisyenId != null)
            //{
            //    cagriViewModel.DestekGrupKullanicilariId = _destekGrupKullanicilariService.GetDestekGrupKullaniciByTeknisyenAndByGrupId(cagriViewModel.DestekGrupKullanicilar.DestekGrupId, cagriViewModel.DestekGrupKullanicilar.TeknisyenId).Id;
            //}
            //cagriViewModel.IstekOlusturanId = _userID;
            if (ModelState.IsValid)
            {
                // IMapper arabirimini enjekte edin
                var mapper = HttpContext.RequestServices.GetService<IMapper>();

                // AutoMapper ile CagriViewModel'den IstekBaslik nesnesine dönüştürme
                var data = mapper.Map<WasteForm>(cagriViewModel);

                var res = _wasteFormService.Insert(data, true);

                //if (res.Exception != null)
                //{
                //    ShowErrorMessage("Hata! İstek Oluşturulamadı.");
                //}
                //else
                //{
                //    ShowSuccessMessage("İstek başarılı bir şekilde oluşturuldu.");
                //    return RedirectToAction("Index", "Cagri");
                //}
            }
            // Model geçerli değilse veya hata varsa, CagriViewModel'i tekrar View'a gönderin.
            return View(cagriViewModel);
        }

    }
}
