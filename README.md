# OOP Assignment 3 — Refactoring, Patterns & Generics

- **Name:** Amr Ayman Fathy Ramadan
- **Email:** amraymanramadan37@gmail.com
- **Branch:** `assignment/1-7`

## Structure

| Folder | Content |
|---|---|
| `Refactoring/part-01` | Shipping (OCP), Orders (DIP), Notifications (composition) + `Refactoring.md` |
| `Refactoring/part-02` | Template Method (Reports), Facade (Enrollment) + `Answers.md` |
| `Refactoring/part-03` | HashSet for blocked users, lazy `yield` students + `Answers.md` |
| `Collections` | Research + collection choices (`Answers.md`), regex extension methods (`src/`) |
| `Generics` | Generic `Store<T>` built step by step (one commit per step) + `Answers.md` |
| `LinkedIn` | `linked.md` with the four public post links |

## How to run

```bash
cd Refactoring/part-01 && dotnet run
cd Refactoring/part-02 && dotnet run
cd Refactoring/part-03 && dotnet run -c Release
cd Collections/src && dotnet run
cd Generics/src && dotnet run
```

## Notes

- Part 01: the new carrier is `EgyptPostCarrier` and the new channel is `WhatsAppChannel`. `Program.cs` is the only existing file edited to wire them in.
- Part 01: `OrderProcessor` uses .NET's built-in `TimeProvider` as the clock abstraction.
- Part 03: timings were measured on my laptop in Release (before ~75 ms, after 0 ms).