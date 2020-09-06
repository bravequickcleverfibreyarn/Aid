using Software9119.Aid.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Software9119.Aid.Collection
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
  static public partial class CollectionExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
  {

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
    /// <summary>
    /// Useful for <see cref="ReadOnlyCollection{T}.ReadOnlyCollection(IList{T})"/> constructor.
    /// </summary>
    /// <param name="emptyForNull">Choses null or empty collection for null source.</param>
    static public IList<T> ToIList<T>(this IEnumerable<T> iEnumerable, bool emptyForNull = default)
    {
      if (iEnumerable == null)
      {
        return emptyForNull ? Array.Empty<T>() : null;
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
    static public ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> iEnumerable, bool emptyForNull = false)
    {
      return iEnumerable.IsNull() && !emptyForNull
        ? null
        : new ReadOnlyCollection<T>(iEnumerable.ToIList(emptyForNull));
    }
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

    #region ReadOnylDictionary

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    static public ReadOnlyDictionary<Key, Source> ToReadOnlyDictionary<Source, Key>(
      this IEnumerable<Source> iEnumerable,
      Func<Source, Key> keySelector,
      bool emptyForNull = false)
    {
      return iEnumerable.ToReadOnlyDictionary(keySelector, v => v, emptyForNull);
    }

    static public ReadOnlyDictionary<Key, Value> ToReadOnlyDictionary<Source, Key, Value>(
      this IEnumerable<Source> iEnumerable,
      Func<Source, Key> keySelector,
      Func<Source, Value> valueSlector,
      bool emptyForNull = false)
    {
      return iEnumerable.IsNull()
        ? emptyForNull
          ? EmptyRODict<Key, Value>()
          : null
        : new ReadOnlyDictionary<Key, Value>(iEnumerable.ToDictionary(keySelector, valueSlector));
    }

    static public ReadOnlyDictionary<Key, Value> AsReadOnlyDictionary<Key, Value>(this Dictionary<Key, Value> dict, bool emptyForNull = false)
    {
      return dict.IsNull()
        ? emptyForNull
          ? EmptyRODict<Key, Value>()
          : null
        : new ReadOnlyDictionary<Key, Value>(dict);
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    static ReadOnlyDictionary<Key, Value> EmptyRODict<Key, Value>() => new ReadOnlyDictionary<Key, Value>(new Dictionary<Key, Value> { });

    #endregion
  }
}