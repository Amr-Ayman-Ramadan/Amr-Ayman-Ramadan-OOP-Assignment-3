using Generics;

// ---- 5 students and 3 courses ----
var students = new Store<Student>();
students.Add(new Student { Id = 1, Name = "Amr" });
students.Add(new Student { Id = 2, Name = "Sara" });
students.Add(new Student { Id = 3, Name = "Omar" });
students.Add(new Student { Id = 4, Name = "Mona" });
students.Add(new Student { Id = 5, Name = "Youssef" });

var courses = new Store<Course>();
courses.Add(new Course { Id = 10, Title = "C# Basics", Price = 1500m });
courses.Add(new Course { Id = 20, Title = "OOP", Price = 2000m });
courses.Add(new Course { Id = 30, Title = "ASP.NET Core", Price = 3500m });

// ---- get one of each by id ----
Console.WriteLine("=== GetById ===");
Console.WriteLine($"Student 3: {students.GetById(3)}");
Console.WriteLine($"Course 20: {courses.GetById(20)}");
Console.WriteLine($"Student 99: {students.GetById(99)?.ToString() ?? "not found"}");
Console.WriteLine();

// ---- duplicate id ----
Console.WriteLine("=== Duplicate Id ===");
try
{
    students.Add(new Student { Id = 2, Name = "Another Sara" });
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}
Console.WriteLine();

// ---- page 2 (size 2) of the students ----
Console.WriteLine("=== Students page 2 (size 2) ===");
foreach (var student in students.GetAll().Page(2, 2))
    Console.WriteLine(student);
Console.WriteLine();

// ---- FindById on a plain List<Course> ----
Console.WriteLine("=== FindById on a plain List<Course> ===");
var courseList = new List<Course>
{
    new() { Id = 100, Title = "Git & GitHub", Price = 500m },
    new() { Id = 200, Title = "SQL Server", Price = 1800m }
};
Console.WriteLine(courseList.FindById(200));
Console.WriteLine();

// ---- ToIdDictionary ----
Console.WriteLine("=== ToIdDictionary ===");
var byId = courses.GetAll().ToIdDictionary();
Console.WriteLine($"Course 30 from dictionary: {byId[30]}");

// must NOT compile: string does not implement IHasId (see Answers.md)
// var strings = new Store<string>();