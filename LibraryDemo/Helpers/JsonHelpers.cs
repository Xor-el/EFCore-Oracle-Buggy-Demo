using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryDemo.Helpers
{
    public static class JsonHelpers
    {
        public static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public static string? ToJson(this object? input) => input is null ? null : JsonSerializer.Serialize(input, JsonOptions);

        public static T? FromJson<T>(this string? input) => string.IsNullOrWhiteSpace(input) ? default : JsonSerializer.Deserialize<T>(input, JsonOptions);
    }
}
