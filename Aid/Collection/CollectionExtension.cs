using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Software9119.Aid.Collection
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
  public static class CollectionExtension
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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