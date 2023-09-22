using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EntitiesLayer;
using EntitiesLayer.DTO;

namespace DataAccessLayer.Mappings
{
	public static class AutoMapper
	{

		private static IMapper _mapper;

		public static IMapper Mapper
		{
			get
			{
				if (_mapper != null) return _mapper;

				var config = new MapperConfiguration(config =>
				{
					config.CreateMap<City, CityDTO>();
					config.CreateMap<City, CityDTO>().ReverseMap();

					config.CreateMap<District, DistrictDTO>();
					config.CreateMap<District, DistrictDTO>().ReverseMap();

					config.CreateMap<Factory, FactoryDTO>();
					config.CreateMap<Factory, FactoryDTO>().ReverseMap();


					config.CreateMap<StockingMethod, StockingMethodDTO>();
					config.CreateMap<StockingMethod, StockingMethodDTO>().ReverseMap();

					config.CreateMap<User, UserDTO>();
					config.CreateMap<User, UserDTO>().ReverseMap();

					config.CreateMap<WasteCode, WasteCodeDTO>();
					config.CreateMap<WasteCode, WasteCodeDTO>().ReverseMap();

					config.CreateMap<WasteForm, WasteFormDTO>();
					config.CreateMap<WasteForm, WasteFormDTO>().ReverseMap();

					config.CreateMap<WasteFormImage, WasteFormImage>();
					config.CreateMap<WasteFormImage, WasteFormImageDTO>().ReverseMap();
				});

				_mapper = config.CreateMapper();
				return _mapper;
			}
		}

		private static int SomeConversionMethod(long sourceId)
		{
			// src.Id değerini uygun bir şekilde dönüştürme işlemleri
			// Örnek olarak:
			return (int)sourceId; // Veya başka bir dönüştürme işlemi yapabilirsiniz.
		}
	}
}
