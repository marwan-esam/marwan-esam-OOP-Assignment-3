using System.Diagnostics.Contracts;

namespace Generics;

public class Student : IHasId
{
  public int Id {get;}
  public string Name {get;}

  public Student(int id, string name)
  {
    Id = id;
    Name = name;
  }

  public override string ToString()
  {
    return $"[Student] ID: {Id}, Name: {Name}";
  }
}