﻿using AutoMapper;
using Help247.Data.Entities;
using Help247.Service.BO.Customer;
using Help247.Service.BO.Feedback;
using Help247.Service.BO.HelpCentre;
using Help247.Service.BO.Helper;
using Help247.Service.BO.HelperCategory;
using Help247.Service.BO.Image;
using Help247.Service.BO.Lookup;
using Help247.Service.BO.Security;
using Help247.Service.BO.Skill;
using Help247.Service.BO.Ticket;
using Help247.ViewModels.Account;
using Help247.ViewModels.Customer;
using Help247.ViewModels.Feedback;
using Help247.ViewModels.HelpCentre;
using Help247.ViewModels.Helper;
using Help247.ViewModels.HelperCategory;
using Help247.ViewModels.Image;
using Help247.ViewModels.Lookup;
using Help247.ViewModels.Skill;
using Help247.ViewModels.Ticket;

namespace Help247.Utilities.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //User
            CreateMap<User, UserBO>().ReverseMap();
            CreateMap<RegisterViewModel, UserBO>().ReverseMap();
            CreateMap<AdminRegisterViewModel, UserBO>().ReverseMap();
            CreateMap<LoginViewModel, LoginBO>().ReverseMap();
            CreateMap<Helper, UserBO>().ReverseMap();
            CreateMap<Customer, UserBO>().ReverseMap();
            CreateMap<ConfirmEmailViewModel, ConfirmEmailBO>().ReverseMap();
            CreateMap<ForgotPasswordViewModel, ForgotPasswordBO>().ReverseMap();
            CreateMap<ResetPasswordViewModel, ResetPassowordBO>().ReverseMap();

            //Helper
            CreateMap<Helper, HelperBO>().ReverseMap();
            CreateMap<HelperViewModel, HelperBO>().ReverseMap();
            CreateMap<HelperSearchViewModel, HelperSearchBO>().ReverseMap();
            

            //Customer
            CreateMap<Customer, CustomerBO>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerBO>().ReverseMap();

            //Ticket
            CreateMap<TicketViewModel, TicketBO>().ReverseMap();
            CreateMap<Ticket, TicketBO>().ReverseMap();
            CreateMap<TicketSearchViewModel, TicketSearchBO>().ReverseMap();
            CreateMap<TicketCountViewModel, TicketCountBO>().ReverseMap();

            //Feedback
            CreateMap<Feedback, FeedbackBO>().ReverseMap();
            CreateMap<FeedbackViewModel, FeedbackBO>().ReverseMap();
            CreateMap<FeedbackSearchViewModel, FeedbackSearchBO>().ReverseMap();

            //HelperCategory
            CreateMap<HelperCategoryViewModel, HelperCategoryBO>().ReverseMap();
            CreateMap<HelperCategory, HelperCategoryBO>().ReverseMap();
            CreateMap<SubService, SubServiceBO>().ReverseMap();
            CreateMap<HelperCategoryDropDownBO, HelperCategoryBO>().ReverseMap();

            //HelpCentre
            CreateMap<HelpCentre, HelpCentreBO>().ReverseMap();
            CreateMap<HelpCentreViewModel, HelpCentreBO>().ReverseMap();
            CreateMap<HelpCentreUpdateViewModel, HelpCentreUpdateBo>().ReverseMap();

            //Image
            CreateMap<ImageViewModel, ImageBO>().ReverseMap();
            CreateMap<Image, ImageBO>().ReverseMap();
            CreateMap<ImageUrlViewModel, ImageUrlBO>().ReverseMap();
            CreateMap<ImageHelperCategoryViewModel, ImageHelperCatergoryBO>().ReverseMap();

            //Skill
            //CreateMap<SkillViewModel, SkillBO>().ReverseMap();
            CreateMap<Skill, SkillBO>().ReverseMap();
            CreateMap<SkillListViewModel, SkillListBO>().ReverseMap();

            //Lookup
            CreateMap<ContactUsViewModel, ContactUsBO>().ReverseMap();




        }
    }
}
