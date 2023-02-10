using DotNetNinja.Web.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetNinja.Web.Core.Tests;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddDotNetNinjaWeb_ShouldAddDefaultTimeProviderToServices()
    {
        var services = new ServiceCollection();

        services.AddDotNetNinjaWeb();

        var registration = services.SingleOrDefault(s => s.ServiceType == typeof(ITimeProvider));

        registration.Should().NotBeNull();
        registration!.ImplementationType.Should().Be(typeof(DefaultTimeProvider));
    }

    [Fact]
    public void AddDotNetNinjaWeb_ShouldAddScopedITimeProviderToServices()
    {
        var services = new ServiceCollection();

        services.AddDotNetNinjaWeb();

        var registration = services.SingleOrDefault(s => s.ServiceType == typeof(ITimeProvider));

        registration.Should().NotBeNull();
        registration!.Lifetime.Should().Be(ServiceLifetime.Scoped);
    }
}