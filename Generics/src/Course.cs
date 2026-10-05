namespace Generics;

public class Course : IHasId
{
  public int Id {get;}
  public string Title {get;}
  public decimal Price {get; private set;}

  public Course(int id, string title, decimal price)
  {
    Id = id;
    Title = title;
    Price = price;
  }
}