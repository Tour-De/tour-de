using System.Text.Json;
using System.Text.Json.Serialization;
using TourDe.Core;

namespace TourDe.Api.Helpers;

/// <summary>
/// Helper parser to accommodate non-ISO8601 formats.
/// </summary>
public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    /// <inheritdoc />
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var s = reader.GetString();
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new Exception(ExceptionMessages.InvalidDate);
        }

        return DateTime.Parse(s);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}