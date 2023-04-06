using System.Text.Json;
using System.Text.Json.Serialization;

namespace TourDe.Api.Helpers;

/// <summary>
/// Helper parser to accommodate non-ISO8601 formats.
/// </summary>
public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    /// <inheritdoc />
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString() ?? string.Empty);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}