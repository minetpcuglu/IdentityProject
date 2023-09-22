using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer.DTO;
using EntitiesLayer;
using DataAccessLayer.Repository;
using System.Numerics;
using EntitiesLayer.Enums;
using CoreLayer.DataAccess.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
	public class WasteFormService : BaseService<WasteForm>, IWasteFormService
	{
		private readonly IWasteFormRepository _wasteFormRepository;

		public WasteFormService(IWasteFormRepository wasteFormRepository) : base(wasteFormRepository)
		{
			_wasteFormRepository = wasteFormRepository;

		}

		//public override ResponseModel<WasteForm> Insert(WasteForm entity, bool save = false)
		//{
		//	//SlaDurumBelirle(entity);
		//	//GrupBelirle(entity);
		//	////_istekRepository.Add(entity);

		//	var istekBaslik = new WasteForm()
		//	{
		//		CompanyName=entity.CompanyName,
		//		SendEmail=entity.SendEmail,
		//		Phone=entity.Phone,
		//		MonthlyAmount=entity.MonthlyAmount,
		//		SendMailIsSuccess=true,
		//		FactoryId=entity.FactoryId,
		//		StockingMethodEnum=StockingMethodEnum.Cuval,
		//		AddressLine=entity.AddressLine,
		//		Aktif=true,
		//		Description=entity.Description,
		//		DistrictId=1041,
				
		//		WasteCodeId=entity.WasteCodeId,
		//		EklenmeZamani=DateTime.Now

		//	};
		//	var value = istekBaslik;
		//	//var istekBaslikId = DataAccessLayer.Mappings.AutoMapper.Mapper.Map<WasteForm>(istekBaslik);
			
		//	var Deneme = base.Insert(istekBaslik, true);
		//	//try
		//	//{
		//	//	var istekLogDTO = new IstekLogDTO()
		//	//	{
		//	//		//konu -oğe -kategori - altkategori -sirket

		//	//		IstekBaslikId = istekBaslikId.Id,
		//	//		Aciklama = kullaniciMail + "Yeni çağrı oluşturdu",
		//	//		OgeId = istekBaslikId.OgeId,
		//	//		KullaniciMail = kullaniciMail,
		//	//		IstekID = Convert.ToInt16(istekBaslikId.Id),
		//	//		IstekKonu = istekBaslikId.IstekKonu,
		//	//		IstekLogEnum = IstekLogEnum.Eklendi,
		//	//		KullaniciId = istekBaslikId.IstekKullaniciId,
		//	//		SirketId = istekBaslikId.SirketId,
		//	//		//şirket eklencek,
		//	//		KategoriId = istekBaslikId.KategoriId,
		//	//		AltKategoriId = istekBaslik.AltKategoriId,
		//	//		EklenmeZamani = DateTime.Now,
		//	//		Aktif = true,
		//	//	};
		//	//	var istekLog = DataAccess.Mappings.AutoMapper.Mapper.Map<Entities.Logs.IstekLog>(istekLogDTO);

		//	//	_istekLogService.Insert(istekLog, true);
		//	//}
		//	//catch (Exception ex)
		//	//{
		//	//	throw;
		//	//}




		//	return new ResponseModel<WasteForm>
		//	{
		//		Data = istekBaslik,
		//		Message = "IstekBaslik inserted successfully.", // İsteğe bağlı, uygun mesajı ekleyebilirsiniz.
		//		isSucceeded = true // İsteğe bağlı, isteğin başarıyla tamamlandığını gösterir.
		//	};
		//}

		public IEnumerable<WasteFormDTO> GetAllWasteForm()
		{
			var city = _wasteFormRepository.GetQueryable().Where(x => x.SilinmeZamani == null && x.Aktif == true)
					.Select(c => new WasteFormDTO
					{
						Id = c.Id,
						CompanyName = c.CompanyName,
						SendEmail=c.SendEmail,
						Phone=c.Phone,
						MonthlyAmount=c.MonthlyAmount,
						//StockingMethod=c.StockingMethod.Name,
						AddressLine=c.AddressLine,
						Description=c.Description,
						SendMailIsSuccess=c.SendMailIsSuccess,
						Aktif = c.Aktif,
						
						WasteCodeName=c.WasteCode.Name,
						WasteCodeDescription=c.WasteCode.Description
					}).ToList();

			return city;
		}
	}
}
