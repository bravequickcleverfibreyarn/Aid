using System;
using System.Collections.Generic;

namespace Software9119.Aid.Enumerable
{
  /// <summary>
  /// Methods strictly designed to be used on pure <see cref="IEnumerable{T}"/>.
  /// </summary>
  static public class EnumerableExtensions
  {

    /// <summary>
    ///Can bypass T[] widening during enumeration if its size is known beforehand.
    /// </summary>       
    static public T[] ToArray<T>(this IEnumerable<T> iEnumerable, int length)
    {
      var arr = new T[length];

      int index = -1;
      foreach (T item in iEnumerable)
      {
        arr[++index] = item;
      }

      return arr;
    }

    /// <summary>
    ///Can bypass <see cref="List{T}"/> widening during enumeration if its size is known beforehand.
    /// </summary>       
    static public List<T> ToList<T>(this IEnumerable<T> iEnumerable, int count)
    {
      var list = new List<T>(count);
      foreach (T item in iEnumerable)
      {
        list.Add(item);
      }

      return list;
    }

    /// <summary>
    ///Can bypass <see cref="Dictionary{Key,Value}"/> widening during enumeration if its size is known beforehand.
    /// </summary>       
    static public Dictionary<Key, Value> ToDictionary<Key, Value>
    (
      this IEnumerable<Value> iEnumerable,
      Func<Value, Key> keySelector,
      int count)
    {
      return ToDictionary(iEnumerable, keySelector, value => value, count);
    }

    /// <summary>
    ///Can bypass <see cref="Dictionary{Key,Value}"/> widening during enumeration if its size is known beforehand.
    /// </summary>       
    static public Dictionary<Key, Value> ToDictionary<Key, Value, Source>
    (
      this IEnumerable<Source> iEnumerable,
      Func<Source, Key> keySelector,
      Func<Source, Value> valueSelector,
      int count)
    {
      var dict = new Dictionary<Key, Value>(count);

      foreach (Source item in iEnumerable)
      {
        dict.Add(keySelector(item), valueSelector(item));
      }

      return dict;
    }
  }
}

