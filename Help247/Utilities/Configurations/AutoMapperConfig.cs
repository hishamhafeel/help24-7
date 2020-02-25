using AutoMapper;
using Help247.Data.Entities;
using Help247.ListModels;
using Help247.Service.BO.Customer;
using Help247.Service.BO.Helper;
using Help247.Service.BO.Security;
using Help247.ViewModels.Account;
using Help247.ViewModels.Customer;
using Help247.ViewModels.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.Utilities.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //User
            CreateMap<User, UserBO>().ReverseMap();
            CreateMap<RegisterViewModel, UserBO>().ReverseMap();
            CreateMap<LoginViewModel, LoginBO>().ReverseMap();
            CreateMap<Helper, UserBO>().ReverseMap();
            CreateMap<Customer, UserBO>().ReverseMap();

            //Helper
            CreateMap<Helper, HelperBO>().ReverseMap();
            CreateMap<HelperViewModel, HelperBO>().ReverseMap();
            CreateMap<HelperCategoryListModel, HelperCategoryListBO>().ReverseMap();

            //Customer
            CreateMap<Customer, CustomerBO>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerBO>().ReverseMap();

        }
    }
}
