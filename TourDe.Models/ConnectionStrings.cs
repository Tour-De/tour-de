namespace TourDe.Models;

public sealed class ConnectionStrings
{
    public const string ConnectionStringsSectionName = "ConnectionStrings";

    public string DefaultConnectionString { get; set; } = string.Empty;
}