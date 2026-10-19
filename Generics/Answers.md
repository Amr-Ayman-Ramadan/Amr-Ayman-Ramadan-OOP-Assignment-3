# Generics Answers

## Step 2 — StudentStore vs CourseStore

**What is the same:**
- Both keep their items in a private `List<...>`.
- Both have the same four methods: `Add`, `GetById`, `GetAll`, `Remove`.
- The code inside every method is the same: `Add` adds to the list, `GetById` loops and compares `Id` and returns `null` if nothing matches, `GetAll` returns the list, and `Remove` finds the item by id and removes it.
- Both depend on the item having an `int Id`.

**What is different:**
- Only the type: one works with `Student`, the other with `Course` (the list type, the parameter type, and the return types).
- The other properties (`Name` vs `Title` and `Price`) are not used by the store at all.

So the two classes are copies of each other with a different type name. Every new entity (Teacher, Room, ...) would need another copy, and a bug fixed in one copy must be fixed in all the others. This duplication is what generics will remove.






## Step 3 — Store<T> and the compiler error

**Compiler error:**

```
error CS1061: 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly reference?)
```

**Why the compiler rejects it:**
Inside `Store<T>` the compiler does not know what `T` will be. `T` could be `Student`, but it could also be `string`, `int`, or any other type, and most types do not have an `Id` property. The compiler checks the generic class **once**, for every possible `T`, not later for each type I use. With no constraint, the only members it can be sure `T` has are the members of `object` (`ToString`, `Equals`, `GetHashCode`, `GetType`). `Id` is not one of them, so `item.Id` cannot compile. I have to tell the compiler that every `T` has an `Id`, and that is what Step 4 does with `where T : IHasId`.



## Step 5 — choices I made

- **Dictionary<int, T>:** `GetById` is now O(1) on average with `TryGetValue` instead of an O(n) loop over a list.
- **Duplicate Id:** `Add` checks `ContainsKey` and throws an `InvalidOperationException` with a clear message (type name + Id).
- **GetAll return type:** `IReadOnlyCollection<T>`. The caller can loop over the items and read `Count`, but it has no `Add` or `Remove`, so it cannot change the store.

## Step 7 — Why `new Store<string>()` must NOT compile

`Store<T>` has the constraint `where T : IHasId`, which means "`T` must be a type that implements `IHasId`". `string` does not implement `IHasId` (it has no `Id`), so it breaks the constraint and the compiler rejects it:

```
error CS0311: The type 'string' cannot be used as type parameter 'T' in the generic type or method 'Store<T>'. There is no implicit reference conversion from 'string' to 'Generics.IHasId'.
```

This is a good thing: the mistake is caught at compile time instead of crashing at runtime. The constraint is what lets `Store<T>` safely use `item.Id`, so it must not accept a type that has no `Id`.

## Last question — what is this kind of class called?

A class like `Store<T> where T : IHasId`, which stores entities by their Id and gives `Add`, `GetById`, `GetAll` and `Remove` for any entity type, is called a **Generic Repository** (the *Repository pattern* implemented with generics). Here it is an in-memory repository, because it keeps the data in a `Dictionary` instead of a database.