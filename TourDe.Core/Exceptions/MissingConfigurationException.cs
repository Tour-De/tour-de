namespace TourDe.Core.Exceptions;

public sealed class MissingConfigurationException : Exception
{
    public MissingConfigurationException(string settingName) : base($"Missing configuration setting {settingName}")
    {
    }
}