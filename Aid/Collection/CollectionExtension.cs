using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace Software9119.Aid.Collection
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
  static public class CollectionExtension
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
  {

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
    /// <summary>
    /// Useful for <see cref="ReadOnlyCollection{T}.ReadOnlyCollection(IList{T})"/> constructor.
    /// </summary>    
    /// <param name="emptyForNull">Choses null or empty collection for null source.</param>
    static public IList<T> ToIList<T>(this IEnumerable<T> iEnumerable, [Optional] bool emptyForNull)
    {
      if (iEnumerable == null)
      {
        return emptyForNull ? new T[0] : null;
      }

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

    /// <summary>
    /// The <see cref="ReadOnlyCollection{T}"/> from any enumerable.
    /// </summary>
    /// <param name="emptyForNull">Choses null or empty collection for null source.</param>
    static public ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> iEnumerable, [Optional] bool emptyForNull)
    {
      return iEnumerable == null && !emptyForNull ? null : new ReadOnlyCollection<T>(iEnumerable.ToIList(emptyForNull));
    }

#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
  }
}