using DotNetNinja.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetNinja.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDotNetNinjaWeb(this IServiceCollection services)
    {
        services.AddScoped<ITimeProvider, DefaultTimeProvider>();
        return services;
    }
}