namespace Generics;

public class StudentStore
{
  private List<Student> _students = [];
  
  public void Add(Student newStudent)
  {
    ArgumentNullException.ThrowIfNull(newStudent);
    _students.Add(newStudent);
  }

  public Student? GetById(int id)
  {
    foreach(Student student in _students)
    {
      if(student.Id == id) return  student;
    }
    return null;
  }

  public IReadOnlyList<Student> GetAll()
  {
    return _students;
  }

  public bool Remove(int id)
  {
    foreach(Student student in _students)
    {
      if(student.Id == id)
      {
        _students.Remove(student);
        return true;
      }
    }
    return false;
  }
}