namespace DotNetNinja.Web.Services;

public interface ITimeProvider
{
    DateTime Now { get; }
    DateTimeOffset OffsetNow { get; }
    DateTime RequestTime { get; }
    DateTimeOffset RequestOffsetTime { get; }
}