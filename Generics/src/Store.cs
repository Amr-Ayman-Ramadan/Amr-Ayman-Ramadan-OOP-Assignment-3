namespace Generics;

public class Store<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);

    // Does NOT compile - see Answers.md (Step 3):
    // error CS1061: 'T' does not contain a definition for 'Id' and no accessible
    // extension method 'Id' accepting a first argument of type 'T' could be found
    //
    // public T? GetById(int id)
    // {
    //     foreach (var item in _items)
    //     {
    //         if (item.Id == id)
    //             return item;
    //     }
    //     return default;
    // }

    public List<T> GetAll() => _items;

    // Remove(int id) needs GetById, so it has the same problem:
    // public bool Remove(int id)
    // {
    //     var item = GetById(id);
    //     return item is not null && _items.Remove(item);
    // }
}