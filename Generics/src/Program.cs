using Generics;

var students = new Store<Student>();
students.Add(new Student { Id = 1, Name = "Amr" });
students.Add(new Student { Id = 2, Name = "Sara" });
Console.WriteLine(students.GetById(2));

var courses = new Store<Course>();
courses.Add(new Course { Id = 10, Title = "C# Basics", Price = 1500m });
courses.Add(new Course { Id = 20, Title = "OOP", Price = 2000m });
Console.WriteLine(courses.GetById(20));


try
{
    students.Add(new Student { Id = 2, Name = "Another Sara" });
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

Console.WriteLine($"Students count: {students.GetAll().Count}");