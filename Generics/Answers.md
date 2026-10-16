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