using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using IdentityProject.DTOLayer.DTOs.AppUserDto;
using IdentityProject.DTOLayer.DTOs.CustomerAccountDto;
using IdentityProject.EntityLayer.Concrete;
using Microsoft.AspNet.Identity;

namespace IdentityProject.DataAccessLayer.Mappings
{
    public static class ModelMapper
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper != null) return _mapper;

                var config = new MapperConfiguration(cfg =>
                {
                    _ = cfg.CreateMap<CustomerAccount,CustomerAccountDto>();
                    _ = cfg.CreateMap<CustomerAccount, CustomerAccountDto>().ReverseMap();

                    _ = cfg.CreateMap<AppUser, AppUserRegisterDto>();
                    _ = cfg.CreateMap<AppUser, AppUserRegisterDto>().ReverseMap();


                });

                _mapper = config.CreateMapper();
                return _mapper;
            }
        }
    }
}
