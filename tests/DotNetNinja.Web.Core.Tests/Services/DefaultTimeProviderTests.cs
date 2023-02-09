using DotNetNinja.Web.Services;
using FluentAssertions;

namespace DotNetNinja.Web.Core.Tests.Services;

public class DefaultTimeProviderTests
{
    private static readonly TimeSpan DefaultTolerance = TimeSpan.FromMilliseconds(5);

    [Fact]
    public void Now_ShouldReturnCurrentDateTime()
    {
        var provider = CreateSut();

        provider.Now.Should().BeCloseTo(DateTime.Now, DefaultTolerance);
    }

    [Fact]
    public void OffsetNow_ShouldReturnCurrentDateTimeOffset()
    {
        var provider = CreateSut();

        provider.OffsetNow.Should().BeCloseTo(DateTimeOffset.Now, DefaultTolerance);
    }

    [Fact]
    public async Task RequestTime_ShouldReturnInstantiationTime()
    {
        var instantiationTime = DateTime.Now;
        var provider = CreateSut();

        await Task.Delay(100);

        provider.RequestTime.Should().BeCloseTo(instantiationTime, DefaultTolerance);
    }

    [Fact]
    public async Task RequestTime_ShouldAlwaysBeTheSameForAGivenInstance()
    {
        var instantiationTime = DateTime.Now;
        var provider = CreateSut();

        var time1 = provider.RequestTime;
        await Task.Delay(100);
        var time2 = provider.RequestTime;
        await Task.Delay(100);
        var time3 = provider.RequestTime;

        provider.RequestTime.Should().Be(time1);
        provider.RequestTime.Should().Be(time2);
        provider.RequestTime.Should().Be(time3);
    }

    [Fact]
    public async Task RequestOffsetTime_ShouldReturnInstantiationTime()
    {
        var instantiationTime = DateTime.Now;
        var provider = CreateSut();

        await Task.Delay(100);

        provider.RequestOffsetTime.Should().BeCloseTo(instantiationTime, DefaultTolerance);
    }

    [Fact]
    public async Task RequestOffsetTime_ShouldAlwaysBeTheSameForAGivenInstance()
    {
        var instantiationTime = DateTime.Now;
        var provider = CreateSut();

        var time1 = provider.RequestOffsetTime;
        await Task.Delay(100);
        var time2 = provider.RequestOffsetTime;
        await Task.Delay(100);
        var time3 = provider.RequestOffsetTime;

        provider.RequestOffsetTime.Should().Be(time1);
        provider.RequestOffsetTime.Should().Be(time2);
        provider.RequestOffsetTime.Should().Be(time3);
    }


    private DefaultTimeProvider CreateSut()
    {
        return new DefaultTimeProvider();
    }
}