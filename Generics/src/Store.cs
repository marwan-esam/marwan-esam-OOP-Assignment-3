using System.Runtime.CompilerServices;

namespace Generics;

public class Store<T> where T : class, IHasId
{
  private Dictionary<int, T> _items = [];
  public void Add(T newItem)
  {
    ArgumentNullException.ThrowIfNull(newItem);
    if(!_items.TryAdd(newItem.Id, newItem)) throw new InvalidOperationException($"Cannot add another {(newItem is Student ? "student" : "course")} with the same id");
  }

  public T? GetById(int id)
  {
    T? item = null;
    _items.TryGetValue(id, out item);
    return item;
  }

  public IEnumerable<T> GetAll()
  {
    return _items.Values;
  }

  public bool Remove(int id)
  {
    return _items.Remove(id);
  }
}