using AutoMapper;

namespace Common.Extensions;

public static class MapperExtensions
{
    public static T Map<T>(this object? o, IMapper mapper)
    {
        return mapper.Map<T>(o);
    }

    public static List<T> MapToList<T>(this IEnumerable<object?> items, IMapper mapper)
    {
        return items.Select(mapper.Map<T>).ToList();
    }
}