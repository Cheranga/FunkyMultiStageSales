using FluentValidation;
using FunkyMultiStageApp;
using FunkyMultiStageApp.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


[assembly:FunctionsStartup(typeof(Startup))]
namespace FunkyMultiStageApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            RegisterServices(services);
            RegisterValidators(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            if (services == null)
            {
                return;
            }

            services.AddSingleton<ICreateNewSalesOrderService, CreateNewSalesOrderService>();
            services.AddSingleton<IShippingService, ShippingService>();
        }

        private void RegisterValidators(IServiceCollection services)
        {
            if (services == null)
            {
                return;
            }

            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
        }
    }
}