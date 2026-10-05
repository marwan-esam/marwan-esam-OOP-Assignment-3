using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Generics;

public class Program
{
  public static void Main(string[] args)
  {
    Store<Student> studentStore = new();
    Store<Course> courseStore = new();

    studentStore.Add(new Student(1, "ahmed"));
    studentStore.Add(new Student(2, "mohamed"));
    studentStore.Add(new Student(3, "mahmoud"));
    studentStore.Add(new Student(4, "ebrahim"));
    studentStore.Add(new Student(5, "marwan"));

    courseStore.Add(new Course(1, "Git", 123.321m));
    courseStore.Add(new Course(2, "OOP", 456.654m));
    courseStore.Add(new Course(3, "Design Patterns", 789.987m));

    Console.WriteLine(studentStore.GetById(4));
    Console.WriteLine(courseStore.GetById(3));

    try
    {
      studentStore.Add(new Student(3, "marwan"));
    } catch(InvalidOperationException e)
    {
      Console.WriteLine(e.Message);
    }

    foreach(var student in studentStore.GetAll().Page(2, 2))
    {
      Console.WriteLine(student);
    }

    var courseList = new List<Course>
    {
      new Course(1, "course 1", 111m),
      new Course(2, "course 2", 222m),
      new Course(3, "course 3", 333m)
    };

    Console.WriteLine(courseList.FindById<Course>(2));

    // new Store<string>();
  }
}