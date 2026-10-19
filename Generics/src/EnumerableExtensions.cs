namespace Generics;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (pageNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "Page number must be 1 or more.");
        if (pageSize < 1)
            throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size must be 1 or more.");

        return PageIterator(source, pageNumber, pageSize);
    }

    private static IEnumerable<T> PageIterator<T>(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        var start = (pageNumber - 1) * pageSize;   
        var end = start + pageSize;                
        var index = 0;

        foreach (var item in source)
        {
            if (index >= end)
                yield break;                     
            if (index >= start)
                yield return item;
            index++;
        }
    }

    public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);

        foreach (var item in source)
        {
            if (item.Id == id)
                return item;
        }
        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);

        var dictionary = new Dictionary<int, T>();
        foreach (var item in source)
        {
            if (!dictionary.TryAdd(item.Id, item))
                throw new ArgumentException($"Duplicate Id {item.Id} found.", nameof(source));
        }
        return dictionary;
    }
}