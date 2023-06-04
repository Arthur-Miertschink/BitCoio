using Microsoft.Extensions.DependencyInjection;
using BitCoio.Handlers.CriarCarteira;
using BitCoio.Handlers.ConsultaSaldo;
using BitCoio.Handlers.DeletarCarteira;

namespace BitCoio.Extensions
{
    public static class MediatrExtension
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(CriarCarteiraRequest)));
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(ConsultaSaldoRequest)));
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(DeletarCarteiraRequest)));

        }
    }
}
