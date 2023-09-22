using AutoMapper;
using CimkoAtikTakipProjectUI.Models;
using EntitiesLayer;

namespace CimkoAtikTakipProjectUI.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// CagriViewModel'den IstekBaslik'a eşleştirme
			CreateMap<WasteFormViewModel, WasteForm>().ReverseMap();
			
			//CreateMap<KullaniciViewModel, KullaniciDTO>().ReverseMap();
			//CreateMap<KullaniciDTO, KullaniciViewModel>().ReverseMap();

	
		}
	}
}
