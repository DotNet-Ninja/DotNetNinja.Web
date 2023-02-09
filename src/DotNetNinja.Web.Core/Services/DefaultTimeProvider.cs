namespace DotNetNinja.Web.Services;

public class DefaultTimeProvider : ITimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTimeOffset OffsetNow => DateTimeOffset.Now;
    public DateTime RequestTime { get; } = DateTime.Now;
    public DateTimeOffset RequestOffsetTime { get; } = DateTimeOffset.Now;
}
