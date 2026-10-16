using Generics;

var students = new StudentStore();
students.Add(new Student { Id = 1, Name = "Amr" });
students.Add(new Student { Id = 2, Name = "Sara" });

Console.WriteLine(students.GetById(2));
Console.WriteLine(students.GetById(99)?.ToString() ?? "not found");