
using System;
using System.Collections.Generic;

namespace Software9119.Aid.Enumerable;

/// <summary>
/// Methods strictly designed to be used on pure <see cref="IEnumerable{T}"/>.
/// </summary>
static public class EnumerableExtensions
{

  /// <summary>
  ///   Can bypass T[] (<seealso cref="Array"/>) widening during enumeration and final fit-size copying if its size is known beforehand.
  /// </summary>       
  /// <exception cref="ArgumentNullException">
  ///   If <paramref name="iEnumerable"/> is <see langword="null"/> and <paramref name="nullForNull"/> is <see langword="false"/>.
  /// </exception>
  static public T [] ToArray<T> ( this IEnumerable<T> iEnumerable, int length, bool nullForNull = false )
  {
    if (NullOrThrow (iEnumerable, nullForNull))
      return null;

    return Unchecked.EnumerableExtensions.ToArray (iEnumerable, length);
  }

  /// <summary>
  ///   Can bypass <see cref="List{T}"/> widening during enumeration if its size is known beforehand.
  /// </summary>    
  /// <exception cref="ArgumentNullException">
  ///   If <paramref name="iEnumerable"/> is <see langword="null"/> and <paramref name="nullForNull"/> is <see langword="false"/>.
  /// </exception>
  static public List<T> ToList<T> ( this IEnumerable<T> iEnumerable, int count, bool nullForNull = false )
  {
    if (NullOrThrow (iEnumerable, nullForNull))
      return null;

    return Unchecked.EnumerableExtensions.ToList (iEnumerable, count);
  }

  /// <summary>
  ///   Can bypass <see cref="Dictionary{Key,Value}"/> widening during enumeration if its size is known beforehand.
  /// </summary>     
  /// <exception cref="ArgumentNullException">
  ///   If <paramref name="iEnumerable"/> is <see langword="null"/> and <paramref name="nullForNull"/> is <see langword="false"/>
  ///   or <paramref name="keySelector"/> is <see langword="null"/>.
  /// </exception>
  static public Dictionary<Key, Value> ToDictionary<Key, Value>
  (
    this IEnumerable<Value> iEnumerable,
    Func<Value, Key> keySelector,
    int count,
    bool nullForNull = false
  )
  {
    if (NullOrThrow (iEnumerable, nullForNull))
      return null;

    if (keySelector is null)
      throw new ArgumentNullException (nameof (keySelector));

    return Unchecked.EnumerableExtensions.ToDictionary (iEnumerable, keySelector, count);
  }

  /// <summary>
  ///   Can bypass <see cref="Dictionary{Key,Value}"/> widening during enumeration if its size is known beforehand.
  /// </summary>     
  /// <exception cref="ArgumentNullException">
  ///   If <paramref name="iEnumerable"/> is <see langword="null"/> and <paramref name="nullForNull"/> is <see langword="false"/>
  ///   or <paramref name="keySelector"/> or <paramref name="valueSelector"/> is <see langword="null"/>.
  /// </exception>
  static public Dictionary<Key, Value> ToDictionary<Key, Value, Source>
  (
    this IEnumerable<Source> iEnumerable,
    Func<Source, Key> keySelector,
    Func<Source, Value> valueSelector,
    int count,
    bool nullForNull = false
  )
  {
    if (NullOrThrow (iEnumerable, nullForNull))
      return null;

    if (keySelector is null)
      throw new ArgumentNullException (nameof (keySelector));

    if (valueSelector is null)
      throw new ArgumentNullException (nameof (valueSelector));

    return Unchecked.EnumerableExtensions.ToDictionary (iEnumerable, keySelector, valueSelector, count);
  }

  static bool NullOrThrow<T> ( IEnumerable<T> iEnumerable, bool nullForNull = false )
  {
    if (iEnumerable is null)
      if (nullForNull)
        return true;
      else
        throw new ArgumentNullException (nameof (iEnumerable));

    return false;
  }
}

