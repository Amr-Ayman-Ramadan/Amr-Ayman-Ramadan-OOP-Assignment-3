using Generics;

var students = new StudentStore();
students.Add(new Student { Id = 1, Name = "Amr" });
students.Add(new Student { Id = 2, Name = "Sara" });

Console.WriteLine(students.GetById(2));
Console.WriteLine(students.GetById(99)?.ToString() ?? "not found");


var courses = new CourseStore();
courses.Add(new Course { Id = 10, Title = "C# Basics", Price = 1500m });
courses.Add(new Course { Id = 20, Title = "OOP", Price = 2000m });

Console.WriteLine(courses.GetById(20));