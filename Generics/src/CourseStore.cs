namespace Generics;

public class CourseStore
{
  private List<Course> _courses = [];
    public void Add(Course newCourse)
    {
      ArgumentNullException.ThrowIfNull(newCourse);
      _courses.Add(newCourse);
    }

  public Course? GetById(int id)
  {
    foreach(Course course in _courses)
    {
      if(course.Id == id) return  course;
    }
    return null;
  }

  public IReadOnlyList<Course> GetAll()
  {
    return _courses;
  }

  public bool Remove(int id)
  {
    foreach(Course course in _courses)
    {
      if(course.Id == id)
      {
        _courses.Remove(course);
        return true;
      }
    }
    return false;
  }
}