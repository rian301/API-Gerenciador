using AutoMapper;
using Black.Application;
using Black.Application.Implement;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Infra.CrossCutting.Identity;
using Black.Infra.CrossCutting.Identity.Extensions;
using Black.Infra.CrossCutting.Identity.Models;
using Black.Repository;
using Black.Repository.Implement;
using Black.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Black.Infra.CrossCutting.Identity.Services;
using Procard.Infra.Data.UoW;
using Black.Service.Implement;
using Procard.Service;
using Procard.Service.Implement;
using Procard.Repository.Implement;
using Procard.Repository;
using Black.Service.Integration.AzureStorage;

namespace Black.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IPasswordHasher<User>, IdentityPasswordHasher<User>>();

            //Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Application
            services.AddScoped<ICustomerApp, CustomerApp>();
            services.AddScoped<ILogErroApp, LogErroApp>();
            services.AddScoped<IPermissionValidateApp, PermissionValidateApp>();
            services.AddScoped<IUserApp, UserApp>();
            services.AddScoped<IUserProfileApp, UserProfileApp>();
            services.AddScoped<IUserProfilePermissionApp, UserProfilePermissionApp>();
            services.AddScoped<ILaunchApp, LaunchApp>();
            services.AddScoped<ICustomerLaunchApp, CustomerLaunchApp>();
            services.AddScoped<IProductApp, ProductApp>();
            services.AddScoped<ICustomerProductApp, CustomerProductApp>();
            services.AddScoped<IAwardApp, AwardApp>();
            services.AddScoped<ICustomerAwardApp, CustomerAwardApp>();
            services.AddScoped<ICustomerPaymentApp, CustomerPaymentApp>();
            services.AddScoped<IPaymentMethodApp, PaymentMethodApp>();
            services.AddScoped<IClassApp, ClassApp>();
            services.AddScoped<IExpenseControlApp, ExpenseControlApp>();
            services.AddScoped<IMentoredApp, MentoredApp>();
            services.AddScoped<IMentoredAwardApp, MentoredAwardApp>();
            services.AddScoped<IMentoredCompanyApp, MentoredCompanyApp>();
            services.AddScoped<IMentoredDocApp, MentoredDocApp>();
            services.AddScoped<IMentoredPaymentApp, MentoredPaymentApp>();
            services.AddScoped<IInvoiceApp, InvoiceApp>();
            services.AddScoped<ISubscriptionApp, SubscriptionApp>();
            services.AddScoped<IEmployeeApp, EmployeeApp>();
            services.AddScoped<IExpenseControlDocApp, ExpenseControlDocApp>();
            services.AddScoped<IProviderApp, ProviderApp>();
            services.AddScoped<IExpenseCategoryApp, ExpenseCategoryApp>();
            services.AddScoped<IPartnerApp, PartnerApp>();
            services.AddScoped<IDailyPaymentApp, DailyPaymentApp>();
            services.AddScoped<IDailyPaymentDocApp, DailyPaymentDocApp>();
            services.AddScoped<IEmployeeDocApp, EmployeeDocApp>();
            services.AddScoped<IAssetsCategoryApp, AssetsCategoryApp>();
            services.AddScoped<IPatrimonyApp, PatrimonyApp>();
            services.AddScoped<IPatrimonyDocApp, PatrimonyDocApp>();
            services.AddScoped<IDocumentApp, DocumentApp>();
            services.AddScoped<IPurchaseControlApp, PurchaseControlApp>();
            services.AddScoped<IPurchaseControlDocApp, PurchaseControlDocApp>();
            services.AddScoped<IPendencyApp, PendencyApp>();
            services.AddScoped<IPendencyDocApp, PendencyDocApp>();
            services.AddScoped<ISentApp, SentApp>();
            services.AddScoped<IAppApp, AppApp>();
            services.AddScoped<IGiftApp, GiftApp>();
            services.AddScoped<IGiftDocApp, GiftDocApp>();

            //Services            
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ILogErroService, LogErroService>();
            services.AddScoped<ILoginRefreshTokenService, LoginRefreshTokenService>();
            services.AddScoped<IPermissionValidateService, PermissionValidateService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IUserProfilePermissionService, UserProfilePermissionService>();
            services.AddScoped<ILaunchService, LaunchService>();
            services.AddScoped<ICustomerLaunchService, CustomerLaunchService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerProductService, CustomerProductService>();
            services.AddScoped<IAwardService, AwardService>();
            services.AddScoped<ICustomerAwardService, CustomerAwardService>();
            services.AddScoped<ICustomerPaymentService, CustomerPaymentService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IExpenseControlService, ExpenseControlService>();
            services.AddScoped<IMentoredService, MentoredService>();
            services.AddScoped<IMentoredAwardService, MentoredAwardService>();
            services.AddScoped<IMentoredCompanyService, MentoredCompanyService>();
            services.AddScoped<IMentoredDocService, MentoredDocService>();
            services.AddScoped<IMentoredPaymentService, MentoredPaymentService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IExpenseControlDocService, ExpenseControlDocService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
            services.AddScoped<IPartnerService, PartnerService>();
            services.AddScoped<IDailyPaymentService, DailyPaymentService>();
            services.AddScoped<IDailyPaymentDocService, DailyPaymentDocService>();
            services.AddScoped<IEmployeeDocService, EmployeeDocService>();
            services.AddScoped<IAssetsCategoryService, AssetsCategoryService>();
            services.AddScoped<IPatrimonyDocService, PatrimonyDocService>();
            services.AddScoped<IPatrimonyService, PatrimonyService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPurchaseControlService, PurchaseControlService>();
            services.AddScoped<IPurchaseControlDocService, PurchaseControlDocService>();
            services.AddScoped<IPendencyService, PendencyService>();
            services.AddScoped<IPendencyDocService, PendencyDocService>();
            services.AddScoped<ISentService, SentService>();
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<IGiftService, GiftService>();
            services.AddScoped<IGiftDocService, GiftDocService>();

            //Repository            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ILogErroRepository, LogErroRepository>();
            services.AddScoped<ILoginRefreshTokenRepository, LoginRefreshTokenRepository>();
            services.AddScoped<IPermissionValidateRepository, PermissionValidateRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserProfilePermissionRepository, UserProfilePermissionRepository>();
            services.AddScoped<ILaunchRepository, LaunchRepository>();
            services.AddScoped<ICustomerLaunchRepository, CustomerLaunchRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerProductRepository, CustomerProductRepository>();
            services.AddScoped<IAwardRepository, AwardRepository>();
            services.AddScoped<ICustomerAwardRepository, CustomerAwardRepository>();
            services.AddScoped<ICustomerPaymentRepository, CustomerPaymentRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IExpenseControlRepository, ExpenseControlRepository>();
            services.AddScoped<IMentoredRepository, MentoredRepository>();
            services.AddScoped<IMentoredCompanyRepository, MentoredCompanyRepository>();
            services.AddScoped<IMentoredDocRepository, MentoredDocRepository>();
            services.AddScoped<IMentoredPaymentRepository, MentoredPaymentRepository>();
            services.AddScoped<IMentoredAwardRepository, MentoredAwardRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExpenseControlDocRepository, ExpenseControlDocRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IDailyPaymentRepository, DailyPaymentRepository>();
            services.AddScoped<IDailyPaymentDocRepository, DailyPaymentDocRepository>();
            services.AddScoped<IEmployeeDocRepository, EmployeeDocRepository>();
            services.AddScoped<IAssetsCategoryRepository, AssetsCategoryRepository>();
            services.AddScoped<IPatrimonyRepository, PatrimonyRepository>();
            services.AddScoped<IPatrimonyDocRepository, PatrimonyDocRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IPurchaseControlRepository, PurchaseControlRepository>();
            services.AddScoped<IPurchaseControlDocRepository, PurchaseControlDocRepository>();
            services.AddScoped<IPendencyRepository, PendencyRepository>();
            services.AddScoped<IPendencyDocRepository, PendencyDocRepository>();
            services.AddScoped<ISentRepository, SentRepository>();
            services.AddScoped<IAppRepository, AppRepository>();
            services.AddScoped<IGiftRepository, GiftRepository>();
            services.AddScoped<IGiftDocRepository, GiftDocRepository>();

            // Integration Services
            services.AddScoped<IAzureStorageService, AzureStorageService>();

            //Others
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IUser, WebUserContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
