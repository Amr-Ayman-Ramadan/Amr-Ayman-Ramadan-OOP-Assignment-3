# Collections Answers

## Task 2.1: Research

### IReadOnlyDictionary<TKey, TValue>
- **What it is:** An interface that represents a collection of key/value pairs that can only be read. It exposes lookup members such as the indexer, `TryGetValue`, `ContainsKey`, `Keys`, `Values`, and `Count`, but it has no `Add`, `Remove`, or `Clear`.
- **Difference from Dictionary:** `Dictionary<TKey,TValue>` is a concrete class that lets you read and also change the data. `IReadOnlyDictionary` is only a read-only *view* (a contract). The class `Dictionary` implements it, so a normal dictionary can be handed out as an `IReadOnlyDictionary`.
- **Why a public method returns it:** So the caller can read the data but cannot add, change, or remove items. This protects the object's internal state (encapsulation) and prevents accidental changes. It also lets me change the internal collection type later without breaking callers.
- **Note:** It is a read-only *view*, not a truly immutable copy. If the owner changes the original `Dictionary`, the view shows the change. A caller could also cast it back to `Dictionary`, so for strict safety I would return a copy or use `ReadOnlyDictionary<TKey,TValue>` / `ImmutableDictionary`.

### SortedDictionary<TKey, TValue>
- **What it is:** A collection of key/value pairs that is always kept sorted by key. It is implemented as a balanced binary search tree (a red-black tree).
- **Ordering vs Dictionary:** `Dictionary` is a hash table and gives no guaranteed order. When I loop over a `SortedDictionary`, the items always come out in key order (by the default comparer or a comparer I provide).
- **Lookup speed vs Dictionary:** `Dictionary` lookup, add, and remove are O(1) on average. `SortedDictionary` lookup, add, and remove are O(log n). So it is slower for lookups, and it also uses more memory.
- **When I would choose it:** When I need the data to always be in key order while items are added or removed at any time, for example a timetable keyed by session start time that must print in time order. If I only need fast lookups and do not care about order, I use `Dictionary`.

### Sources
1. Microsoft Learn: IReadOnlyDictionary<TKey,TValue> Interface
   https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2
2. Microsoft Learn: SortedDictionary<TKey,TValue> Class
   https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2
3. Microsoft Learn: Selecting a Collection Class
   https://learn.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class

## Task 2.2: Pick the Collection

| # | Collection | Why |
|---|------------|-----|
| S1 | `Dictionary` | Looking up a student by national ID (the key) is O(1) on average, so thousands of lookups a day stay fast without looping. |
| S2 | `HashSet` | It does not allow duplicates, so the same tag can never be stored twice, and `Contains` is fast. |
| S3 | `List` | It keeps items in the order they were added and allows duplicate values. |
| S4 | `IReadOnlyDictionary` | Callers can read prices by key but cannot add, change, or remove anything. |
| S5 | `SortedDictionary` | It stays sorted by key (start time) even when sessions are added at any moment, so printing is always in time order. |
| S6 | `IEnumerable` | The caller only loops once and may stop early, so results can be produced lazily with `yield return`. |