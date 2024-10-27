using BOs.Models;
using DataLayer.GenericRepository;
using KoiAPI.AppStarts;
using Microsoft.EntityFrameworkCore;
using Repos;
using Repos.Interface;
using Repos.UnitOfWork;
using Services;
using Services.IServices;
using Services.Modal.Request;

namespace KoiAPI.AppStarts
{
    public static class DependencyInjectionContainers
    {

        public static void InstallService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true; ;
                options.LowercaseQueryStrings = true;
            });


            services.AddDbContext<KoiFarmManagementContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // use DI here
            services.AddScoped<IAuthServices, AuthServices>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepos, UserRepos>();
           
            services.AddScoped<IFarmRepos, FarmRepos>();
            services.AddScoped<IFarmService, FarmService>();
            
            services.AddScoped<IKoiTypeRepos, KoiTypeRepos>();
            services.AddScoped<IKoiTypeService, KoiTypeService>();
            
            services.AddScoped<IOrderRepos, OrderRepos>();
            services.AddScoped<IOrderService, OrderService>();
            
            services.AddScoped<IPaymentRepos, PaymentRepos>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IQuotationRepos, QuotationRepos>();
            services.AddScoped<IQuotationService, QuotationService>();

            services.AddScoped<IReportRepos, ReportRepos>();
            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<IRoleRepos, RoleRepos>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IServiceRequestRepos, ServiceRequestRepos>();
            services.AddScoped<IServiceRequestService, ServiceRequestService>();

            services.AddScoped<ITripRepos, TripRepos>();
            services.AddScoped<ITripService, TripService>();

        }




        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            // use DI here
          
            //services.AddScoped<IWineRequestService, WineRequestService>();


            // auto mapper
            services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);

            services.AddHttpContextAccessor();

            return services;
        }
    }

}
