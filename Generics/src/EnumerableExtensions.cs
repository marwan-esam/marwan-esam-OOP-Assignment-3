namespace Generics;

public static class EnumerableExtensions
{
  public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
  {
    if(pageNumber < 1 || pageSize < 1) throw new ArgumentOutOfRangeException("Page Number and Page Size cannot be less than 1");
    int toSkip = (pageNumber - 1) * pageSize;

    if(source is IList<T> list) // if it's a list we can skip looping from the beginning and use index math instead
    {
      for(int i = toSkip ; i < toSkip + pageSize && i < list.Count ; i++)
      {
        yield return list[i];
      }
    } else // otherwise it's more like a stream (doesn't have indexer) and so we have to loop from the beggining
    {
      int skipped = 0;
      int taken = 0;
      foreach(T item in source)
      {
        if(skipped < toSkip)
        {
          skipped++;
          continue;
        }

        if(taken < pageSize)
        {
          taken++;
          yield return item;
        } else
        {
          break;
        }
      }
    }
  }

  public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
  {
    foreach(T item in source)
    {
      if(item.Id == id) return item;
    }
    return default;
  } 

  public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
  {
    Dictionary<int, T> dictionary = [];
    foreach(T item in source)
    {
      dictionary.TryAdd(item.Id, item);
    }
    return dictionary;
  } 
}