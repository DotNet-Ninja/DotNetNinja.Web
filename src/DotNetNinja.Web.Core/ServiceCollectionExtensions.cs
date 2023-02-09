using DotNetNinja.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetNinja.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDotNetNinjaWeb(this IServiceCollection services)
    {
        services.AddSingleton<ITimeProvider, DefaultTimeProvider>();
        return services;
    }
}