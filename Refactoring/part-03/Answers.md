# Part 03 — answers

---

## BlockedUsers

- **Time complexity before:** O(n × m) — for each of the m requests (5,000), `List<int>.Contains` scans the list of n blocked ids (50,000) one by one. That is up to 250,000,000 comparisons.
- **Time (ms) before:** ~75 ms (3 runs in Release: 75, 89, 60 ms — found = 5000)
- **What did you change?** I changed the blocked ids from `List<int>` to `HashSet<int>` (in `BuildBlockedIds`, `CountBlocked` and `MeasureMs`). A `HashSet` finds an item by its hash code instead of walking the whole list, so `Contains` is O(1) on average. The loop and the counting logic are the same, so `found` does not change.
- **Time complexity after:** O(m) — m lookups, each O(1) on average (building the set is O(n), done once).
- **Time (ms) after:** 0 ms (3 runs in Release: 0, 0, 0 ms — found = 5000). The work is now under 1 ms, so `ElapsedMilliseconds` rounds it down to 0.

---

## Students

- **What was the problem?**
  `GetAllStudents()` built a `List<Student>` with all 1,000,000 students before returning anything (eager). `Program.cs` prints only the first 3 and then `break`s, but by that time the method had already created 1,000,000 `Student` objects and 1,000,000 strings — wasted time and memory.
- **What did you change?**
  I changed the return type to `IEnumerable<Student>` and used `yield return` instead of adding to a list. Now the method is lazy: each student is created only when the `foreach` asks for the next one. When `Program.cs` breaks after 3, the method stops, so only 3 students are created. The output is the same: the first 3 students and `printed=3`.