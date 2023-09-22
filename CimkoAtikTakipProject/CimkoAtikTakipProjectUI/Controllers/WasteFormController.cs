using AutoMapper;
using BusinessLayer.Abstract;
using CimkoAtikTakipProjectUI.Models;
using CimkoAtikTakipProjectUI.Extensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntitiesLayer;
using EntitiesLayer.Enums;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using DevExpress.XtraEditors.Filtering;
using DevExtreme.AspNet.Mvc.Builders;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace CimkoAtikTakipProjectUI.Controllers
{
	public class WasteFormController : Controller
	{
		private readonly IWasteFormService _wasteFormService;
		private readonly IWasteFormImageService _wasteFormImageService;
		private readonly IWasteCodeService _wasteCodeService;
		private readonly IDistrictService _districtService;
		private readonly ICityService _cityService;
		private readonly IFactoryService _factoryService;
		private readonly IStockingMethodService _stockingMethodService;

		public WasteFormController(IWasteFormService wasteFormService, IStockingMethodService stockingMethodService, IWasteFormImageService wasteFormImageService, IFactoryService factoryService, IDistrictService districtService, ICityService cityService, IWasteCodeService wasteCodeService)
		{
			_wasteFormService = wasteFormService;
			_districtService = districtService;
			_cityService = cityService;
			_wasteCodeService = wasteCodeService;
			_factoryService = factoryService;
			_wasteFormImageService = wasteFormImageService;
			_stockingMethodService = stockingMethodService;
		}

		/// <summary>
		/// AtıkForm Ekranıii
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Index(List<IFormFile> base64, string firstName, string lastName)
		{

			return View(base64);
		}

		/// <summary>
		/// Atık Kod Dropdown Listeleme Atık FormTip Durum ve Aktif = true 
		/// </summary>
		/// <param name="loadOptions"></param>
		/// <returns></returns>
		[HttpGet]
		public object GetAllWasteCode(DataSourceLoadOptions loadOptions)
		{
			var WasteCodeList = _wasteCodeService.GetAllWasteCode(); //null
			return DataSourceLoader.Load(WasteCodeList, loadOptions);
		}


		[HttpGet]
		public object GetFactories(DataSourceLoadOptions loadOptions)
		{
			var CityList = _factoryService.GetAllFactory();
			return DataSourceLoader.Load(CityList, loadOptions);
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
		public object GetAllStockingMethod(DataSourceLoadOptions loadOptions)
		{
			var DistrictList = _stockingMethodService.GetAllStockingMethod();
			return DataSourceLoader.Load(DistrictList, loadOptions);
		}


		[HttpGet]
		public IActionResult NewWasteForm(int? id)
		{
			var codeDetails = _wasteCodeService.GetById(id);
			if (codeDetails != null)
			{
				var viewModel = new WasteFormViewModel
				{
					WasteCode = codeDetails,
				};
				return View("_wasteCodeDetailsPartial", viewModel);
			}

			var model = new WasteFormViewModel
			{

			};
			return View(model);

		}


		[HttpPost]

		public IActionResult NewWasteForm(WasteFormViewModel wasteFormViewModel, List<IFormFile> base64, string firstName, string lastName)
		{

			// IMapper arabirimini enjekte edin
			var mapper = HttpContext.RequestServices.GetService<IMapper>();

			// AutoMapper ile CagriViewModel'den IstekBaslik nesnesine dönüştürme
			var data = mapper.Map<WasteForm>(wasteFormViewModel);


			var res = _wasteFormService.Insert(data, true);


			foreach (var file in base64)
			{
				if (file.Length > 0)
				{
					using (var ms = new MemoryStream())
					{
						file.CopyTo(ms);
						var fileBytes = ms.ToArray();
						string base64String = Convert.ToBase64String(fileBytes);


						var wasteFormImage = new WasteFormImage
						{
							//WasteFormStatusEnum = WasteFormStatusEnum.FormOnaylandi,
							EklenmeZamani = DateTime.Now,
							Aktif = true,
							WasteFormId = res.Data.Id,
							Base64 = base64String,
							WasteFormStatusEnum = WasteFormStatusEnum.formGonderildi,

						};

						_wasteFormImageService.Insert(wasteFormImage, true);
					}
				}
			}

			#region SMTP MAİL
			if (res != null)
			{
				try
				{
					var SmtpServer = new SmtpClient("10.10.9.35", 25);



					var mail = new MailMessage { From = new MailAddress("akiktakip@cimko.com.tr") };



					mail.To.Add("ibrahim.serpici@sanko.com.tr");
					mail.CC.Add("mine.topcuoglu@sanko.com.tr");
					//mail.Bcc.Add(); "Gizli kişi



					mail.Subject = "Çimko Müşteri Portal Ödeme Kontrol Result Hata";



					mail.IsBodyHtml = true;



					var htmlBody = "kontrolException.Message;";



					mail.Body = htmlBody;

					SmtpServer.Send(mail);
				}
				catch (Exception ex)
				{
					var hata = ex.Message;
					throw;
				}

				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction("Index", "Home");

			//luinjceusvkzsnmm
			#endregion
		}



	}
}
