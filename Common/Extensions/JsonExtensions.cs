using Newtonsoft.Json;

namespace Common.Extensions;

public static class JsonExtensions
{
    public static string ToJson(this object? item)
    {
        return item != null ? JsonConvert.SerializeObject(item) : "{}";
    }

    public static T? FromJson<T>(this string? json)
    {
        try
        {
            JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($@"{json}\n{ex}");

            return default;
        }

        return json != null ? JsonConvert.DeserializeObject<T>(json) : default;
    }
}