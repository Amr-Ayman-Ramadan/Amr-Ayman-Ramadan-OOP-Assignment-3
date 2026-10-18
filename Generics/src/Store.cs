namespace Generics;

public class Store<T> where T : IHasId
{
    // Keyed by Id, so GetById is O(1) instead of looping over a list.
    private readonly Dictionary<int, T> _items = new();

    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id))
            throw new InvalidOperationException(
                $"An item of type {typeof(T).Name} with Id {item.Id} already exists in the store.");

        _items.Add(item.Id, item);
    }

    public T? GetById(int id) =>
        _items.TryGetValue(id, out var item) ? item : default;

    // Read-only: the caller can loop, count and read,
    // but there is no Add / Remove, so the store cannot be changed from outside.
    public IReadOnlyCollection<T> GetAll() => _items.Values;

    public bool Remove(int id) => _items.Remove(id);
}