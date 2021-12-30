
using Software9119.Aid.Object;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Software9119.Aid.Collection;

static public partial class CollectionExtensions
{

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
  
  /// <summary>
  /// Useful for <see cref="ReadOnlyCollection{T}.ReadOnlyCollection(IList{T})"/> constructor.
  /// </summary>
  /// <param name="emptyForNull">Chooses null or empty collection for null source.</param>
  /// <returns>
  /// <see langword="null"/> when <paramref name="iEnumerable"/> is <see langword="null"/> and <paramref name="emptyForNull"/> is <see langword="false"/>.
  /// </returns>
  static public IList<T> ToIList<T> ( this IEnumerable<T> iEnumerable, bool emptyForNull = false )
  {
    if (iEnumerable == null)
    {
      return emptyForNull ? Array.Empty<T> () : null;
    }

    if (iEnumerable is IList<T> iList)
    {
      return iList;
    }

    if (iEnumerable is ICollection<T>)
    {
      return iEnumerable.ToArray ();
    }

    return iEnumerable.ToList ();
  }

  /// <summary>
  /// The <see cref="ReadOnlyCollection{T}"/> from any enumerable.
  /// </summary>
  /// <param name="emptyForNull">Choses null or empty collection for null source.</param>
  /// <returns>
  /// <see langword="null"/> when <paramref name="iEnumerable"/> is <see langword="null"/> and <paramref name="emptyForNull"/> is <see langword="false"/>.
  /// </returns>
  static public ReadOnlyCollection<T> ToReadOnlyCollection<T> ( this IEnumerable<T> iEnumerable, bool emptyForNull = false )
  {
    return iEnumerable.IsNull () && !emptyForNull
      ? null
      : new ReadOnlyCollection<T> (iEnumerable.ToIList (emptyForNull));
  }
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

  #region ReadOnylDictionary

  /// <returns>
  /// <see langword="null"/> when <paramref name="iEnumerable"/> is <see langword="null"/> and <paramref name="emptyForNull"/> is <see langword="false"/>.
  /// </returns>
  static public ReadOnlyDictionary<Key, Source> ToReadOnlyDictionary<Source, Key> (
    this IEnumerable<Source> iEnumerable,
    Func<Source, Key> keySelector,
    bool emptyForNull = false )
  {
    return iEnumerable.ToReadOnlyDictionary (keySelector, v => v, emptyForNull);
  }

  /// <returns>
  /// <see langword="null"/> when <paramref name="iEnumerable"/> is <see langword="null"/> and <paramref name="emptyForNull"/> is <see langword="false"/>.
  /// </returns>
  static public ReadOnlyDictionary<Key, Value> ToReadOnlyDictionary<Source, Key, Value> (
    this IEnumerable<Source> iEnumerable,
    Func<Source, Key> keySelector,
    Func<Source, Value> valueSlector,
    bool emptyForNull = false )
  {
    return iEnumerable.IsNull ()
      ? emptyForNull
        ? EmptyRODict<Key, Value> ()
        : null
      : new ReadOnlyDictionary<Key, Value> (iEnumerable.ToDictionary (keySelector, valueSlector));
  }

  /// <returns>
  /// <see langword="null"/> when <paramref name="dict"/> is <see langword="null"/> and <paramref name="emptyForNull"/> is <see langword="false"/>.
  /// </returns>
  static public ReadOnlyDictionary<Key, Value> AsReadOnlyDictionary<Key, Value> ( this Dictionary<Key, Value> dict, bool emptyForNull = false )
  {
    return dict.IsNull ()
      ? emptyForNull
        ? EmptyRODict<Key, Value> ()
        : null
      : new ReadOnlyDictionary<Key, Value> (dict);
  }

  static ReadOnlyDictionary<Key, Value> EmptyRODict<Key, Value> () => new (new Dictionary<Key, Value> { });

  #endregion
}
