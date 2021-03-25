using AMS.Infrastructure.Service;
using AMS.Infrastructure.Service.AuthServices;
using AMS.Infrastructure.Service.ChequeServices;
using AMS.Infrastructure.Service.ClientServices;
using AMS.Infrastructure.Service.CollectionCommissionServices;
using AMS.Infrastructure.Service.EmployeeServices;
using AMS.Infrastructure.Service.ExchangeBillServices;
using AMS.Infrastructure.Service.FileServices;
using AMS.Infrastructure.Service.MaintenanceContractServices;
using AMS.Infrastructure.Service.MaintenanceCycleServices;
using AMS.Infrastructure.Service.MaintenanceServiceServices;
using AMS.Infrastructure.Service.MotorServices;
using AMS.Infrastructure.Service.NotificationServices;
using AMS.Infrastructure.Service.PriceOfferServices;
using AMS.Infrastructure.Service.SaleContractServices;
using AMS.Infrastructure.Service.SparePartServices;
using AMS.Infrastructure.Service.SparePartSoldServices;
using AMS.Infrastructure.Service.StorageServices;
using AMS.Infrastructure.Service.TransactionServices;
using AMS.Infrastructure.Service.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace AMS.Infrastructure.Extensions
{
    public static class ServicesRegistryExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddScoped<IChequeService, ChequeService>();
            
            services.AddScoped<IClientService, ClientService>();
            
            services.AddScoped<ICollectionCommissionService, CollectionCommissionService>();
            
            services.AddScoped<IEmployeeService, EmployeeService>();
            
            services.AddScoped<IExchangeBillService, ExchangeBillService>();

            services.AddScoped<IFileService, FileService>();
            
            services.AddScoped<IMaintenanceContractService, MaintenanceContractService>();
            
            services.AddScoped<IMaintenanceCycleService, MaintenanceCycleService>();
            
            services.AddScoped<IMaintenanceServiceService, MaintenanceServiceService>();
            
            services.AddScoped<IMotorService, MotorService>();
            
            services.AddScoped<IPriceOfferService, PriceOfferService>();
            
            services.AddScoped<ISaleContractService, SaleContractService>();
            
            services.AddScoped<ISparePartService, SparePartService>();
            
            services.AddScoped<ISparePartSoldService, SparePartSoldService>();
            
            services.AddScoped<ITransactionService, TransactionService>();
            
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddSingleton<IStorageService, StorageService>();

            services.AddSingleton<INotificationService, NotificationService>();
            
            return services;
        } 
    }
}