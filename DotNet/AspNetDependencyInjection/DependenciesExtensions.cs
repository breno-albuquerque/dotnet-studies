using AspNetDependencyInjection.ImplementationsExamples;
using AspNetDependencyInjection.InterfacesExamples;

namespace AspNetDependencyInjection
{
    //  Classe deve ser ESTÁTICA
    public static class DependenciesExtensions
    {
        //  Métodos devem ser ESTÁTICOS
        public static IServiceCollection AddDependeciesExtensions(this IServiceCollection services)
        {
            //  O retorno poderia ser void
            return services
                .AddRepositories()
                .AddServices();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPromoCodeRepository, PromoCodeRepository>();

            //  O retorno poderia ser void
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryFeeService, DeliveryFeeService>();
            services.AddScoped<IService, ServiceOne>();

            //  O retorno poderia ser void
            return services;
        }
    }
}
