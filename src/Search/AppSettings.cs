namespace Search;

public class AppSettings
{
    public ElasticSearchOption ElasticSearchOption { get; set; }
}

public sealed class ElasticSearchOption
{
    public required string Host { get; init; }
    public required string Fingerprint { get; init; }
    public required string UserName { get; init; }
    public required string Password { get; init; }
}

public sealed class BrokerOptions
{
    public const string SectionName = "BrokerOptions";

    public required string Host { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
}
