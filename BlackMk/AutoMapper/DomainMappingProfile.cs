using AutoMapper;
using Black.API.Admin.ViewModels;
using Black.Application.DTO;
using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Infra.CrossCutting.Identity;
using Black.Infra.CrossCutting.Identity.Models.AccountViewModels;
using BlackMk.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Black.API.AutoMapper
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Customer, CustomerListViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Customer, CustomerPutViewModel>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerPutViewModel, CustomerUpdateDTO>();

            // Permissões, perfis e usuário
            CreateMap<DTOChangeUserProfile, UserProfileViewModel>().ReverseMap();
            CreateMap<DTOUserProfilePermission, UserProfilePermission>().ReverseMap();
            CreateMap<DTOUserProfilePermission, UserProfilePermissionViewModel>().ReverseMap();
            CreateMap<User, UserUpdateViewModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileViewModel>().ReverseMap();
            CreateMap<UserProfilePermission, UserProfilePermissionViewModel>().ReverseMap();
            CreateMap<User, UserListDTO>().ReverseMap();
            CreateMap<Permission, PermissionViewModel>().ReverseMap();
            CreateMap<GetPermissionsByIdUserQueryResult, PermissionsByUserLoggedViewModel>().ReverseMap();

            CreateMap<Launch, LaunchViewModel>().ReverseMap();
            CreateMap<LaunchViewModel, LaunchDTO>().ReverseMap();

            // Customer
            CreateMap<CustomerLaunch, CustomerLaunchViewModel>().ReverseMap();
            CreateMap<CustomerProduct, CustomerProductViewModel>().ReverseMap();
            CreateMap<CustomerAward, CustomerAwardViewModel>().ReverseMap();
            CreateMap<CustomerPayment, CustomerPaymentViewModel>().ReverseMap();

            // Product
            CreateMap<ProductViewModel, Product>().ReverseMap();

            // Award
            CreateMap<Award, AwardViewModel>().ReverseMap();

            // PaymentMethod
            CreateMap<PaymentMethod, PaymentMethodViewModel>().ReverseMap();

            // Class
            CreateMap<Class, ClassViewModel>().ReverseMap();

            // ExpenseControl
            CreateMap<ExpenseControl, ExpenseControlViewModel>()
                .ForMember(m => m.ProviderName, opt => opt.MapFrom(src => src.Provider.Name))
                .ForMember(m => m.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name)).ReverseMap();
            CreateMap<ExpenseControlDoc, ExpenseControlDocViewModel>().ReverseMap();
            CreateMap<ExpenseControl, ExpenseControlPutViewModel>().ReverseMap();

            // Mentored
            CreateMap<Mentored, MentoredQueryResult>().ReverseMap();
            CreateMap<Mentored, GetMentoredAndPartnerQueryResult>().ReverseMap();
            CreateMap<MentoredCompany, MentoredCompanyViewModel>().ReverseMap();
            CreateMap<MentoredDoc, MentoredDocViewModel>().ReverseMap();
            CreateMap<MentoredPayment, MentoredPaymentViewModel>().ReverseMap();
            CreateMap<MentoredPayment, MentoredPaymentListViewModel>().ReverseMap();
            CreateMap<MentoredViewModel, MentoredDTO>().ReverseMap();
            CreateMap<Mentored, MentoredDTO>().ReverseMap();
            CreateMap<MentoredCompanyViewModel, MentoredCompanyDTO>().ReverseMap();
            CreateMap<MentoredViewModel, MentoredQueryResult>().ReverseMap();
            CreateMap<MentoredAwardViewModel, MentoredAward>().ReverseMap();
            CreateMap<Mentored, MentoredViewModel>()
                //.ForMember(m => m.SubscriptionDate, opt => opt.MapFrom(src => src.))
                //.ForMember(m => m.EndSubscriptionDate, opt => opt.MapFrom(src => src.Provider.Name))
                //.ForMember(m => m.TotalAmountContract, opt => opt.MapFrom(src => src.Provider.Name))
                .ForMember(destination => destination.Partners, options => options.MapFrom(source => source.Partners.Select(detail => detail.MentoredPartnerId)
                .ToList()));
            CreateMap<Mentored, GetMentoredAndPartnerQueryResult>()
                .ForMember(destination => destination.Partners, options => options.MapFrom(source => source.Partners.Select(detail => detail.MentoredPartnerId).ToList()));

            CreateMap<MentoredPaymentPutViewModel, MentoredPutPaymentDTO>().ReverseMap();
            CreateMap<SubscriptionPutViewModel, MentoredSubscriptionDTO>().ReverseMap();
            CreateMap<InvoiceViewModel, InvoiceDTO>().ReverseMap();

            // Subscription
            CreateMap<Subscription, SubscriptionViewModel>().ReverseMap();
            CreateMap<Subscription, SubscriptionPutViewModel>().ReverseMap();
            CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(m => m.ProductName, opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<Subscription, MentoredSubscriptionListViewModel>().ReverseMap();
            CreateMap<Subscription, SubscriptionReportViewModel>()
                .ForMember(m => m.MentoredName, opt => opt.MapFrom(src => src.Mentored.Name))
                .ForMember(m => m.MentoredId, opt => opt.MapFrom(src => src.Mentored.Id))
                .ForMember(m => m.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(m => m.AmountTotalContract, opt => opt.MapFrom(src => src.TotalAmount));

            // Invoice
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();
            CreateMap<Invoice, InvoiceReportViewModel>()
                .ForMember(m => m.EndSubscriptionDate, opt => opt.MapFrom(src => src.Subscription.EndSubscriptionDate));

            // Employee
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeViewModel, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeDoc, EmployeeDocViewModel>().ReverseMap();

            // Provider
            CreateMap<Provider, ProviderViewModel>().ReverseMap();

            // Expense category
            CreateMap<ExpenseCategory, ExpenseCategoryViewModel>().ReverseMap();

            // DailyPayment
            CreateMap<DailyPayment, DailyPaymentViewModel>()
                .ForMember(m => m.ProviderName, opt => opt.MapFrom(src => src.Provider.Name))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name)).ReverseMap();
            CreateMap<DailyPayment, DailyPaymentPutViewModel>().ReverseMap();
            CreateMap<DailyPaymentDoc, DailyPaymentDocViewModel>().ReverseMap();

            // AssetsCategory
            CreateMap<AssetsCategory, AssetsCategoryViewModel>().ReverseMap();

            // Ptrimmony
            CreateMap<Patrimony, PatrimonyViewModel>().ReverseMap();
            CreateMap<PatrimonyDoc, PatrimonyDocViewModel>().ReverseMap();
            CreateMap<Patrimony, PatrimonyListViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(src => src.AssetsCategory.Name))
                .ForMember(m => m.ProviderName, opt => opt.MapFrom(src => src.Provider.Name)).ReverseMap();

            // Document
            CreateMap<Document, DocumentViewModel>().ReverseMap();

            // PurchaseControl
            CreateMap<PurchaseControl, PurchaseControlListViewModel>().ReverseMap();
            CreateMap<PurchaseControl, PurchaseControlViewModel>().ReverseMap();
            CreateMap<PurchaseControlDoc, PurchaseControlDocViewModel>().ReverseMap();

            // Pendency
            CreateMap<Pendency, PendencyViewModel>().ReverseMap();
            CreateMap<PendencyDoc, PendencyDocViewModel>().ReverseMap();

            // Sent
            CreateMap<Sent, SentViewModel>()
                .ForMember(m => m.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(m => m.AwardName, opt => opt.MapFrom(src => src.Award.Name))
                .ForMember(m => m.MentoredName, opt => opt.MapFrom(src => src.Mentored.Name))
                .ReverseMap();
            CreateMap<Sent, SentGetViewModel>().ReverseMap();

            // App
            CreateMap<App, AppViewModel>().ReverseMap();

            // Gift
            CreateMap<Gift, GiftViewModel>().ReverseMap();
            CreateMap<GiftDoc, GiftDocViewModel>().ReverseMap();
        }
    }
}
