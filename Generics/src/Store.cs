namespace Generics;

public class Store<T>
{
  private List<T> _items = [];
    public void Add(T newItem)
    {
      ArgumentNullException.ThrowIfNull(newItem);
      _items.Add(newItem);
    }

  public T? GetById(int id)
  {
    foreach(T item in _items)
    {
      if(item.Id == id) return  item;
    }
    return null;
  }

  public IReadOnlyList<T> GetAll()
  {
    return _items;
  }

  public bool Remove(int id)
  {
    foreach(T item in _items)
    {
      if(item.Id == id)
      {
        _students.Remove(student);
        return true;
      }
    }
    return false;
  }
}