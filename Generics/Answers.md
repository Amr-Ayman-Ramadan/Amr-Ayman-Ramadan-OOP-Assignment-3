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