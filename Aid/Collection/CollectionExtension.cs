using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Software9119.Aid.Collection
{

  public static class CollectionExtension
  {

    /// <summary>
    /// Useful for <see cref="ReadOnlyCollection{T}.ReadOnlyCollection(IList{T})"/> constructor.
    /// </summary>    
    public static IList<T> ToIList<T>(this IEnumerable<T> iEnumerable)
    {
      if (iEnumerable is IList<T> iList)
      {
        return iList;
      }

      if (iEnumerable is ICollection<T>)
      {
        return iEnumerable.ToArray();
      }

      return iEnumerable.ToList();
    }

  }
}