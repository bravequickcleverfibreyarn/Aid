using Software9119.Aid.Enumerable;
using Software9119.Aid.Exception;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace Software9119.Aid.Collection;

static public partial class CollectionExtensions
{
  static readonly ConcurrentDictionary<System.Type, System.Type[]> otherTypes      = new();
  static readonly ConcurrentDictionary<System.Type, System.Type[]> immutableTypes  = new();


  /// <summary>    
  /// Helper to cast <paramref name="enumerable"/> or create collection from <paramref name="enumerable"/>.
  /// </summary>
  /// <typeparam name="T"><paramref name="enumerable"/> items type.</typeparam>
  /// <typeparam name="U">Desired as/to type.</typeparam>    
  /// <exception cref="ArgumentRangeExceptionC{T}">When <typeparamref name="U"/> is unsupported creation type.</exception>   
  /// <exception cref="ArgumentNullException">When <paramref name="enumerable"/> is <see langword="null"/> and <paramref name="emptyForNull"/> is <see langword="false"/>.</exception>
  /// <remarks>Supports all types for casting.</remarks>    
#nullable enable
  static public U AsOrTo<T, U> ( this IEnumerable<T> enumerable, bool emptyForNull = false )
  {
    if (enumerable is null)
    {
      if (emptyForNull)
        enumerable = Array.Empty<T> ();
      else
        throw new ArgumentNullException (nameof (enumerable));
    }

    System.Type typeOfU = typeof(U);
    if (enumerable!.GetType () == typeOfU)
      return (U) enumerable;

    if (typeof (T []) == typeOfU)
      return (U) (object) enumerable.ToArray ();

    System.Type typeOfT = typeof (T);
    System.Type[] otherTypers = OtherTypes<T> (typeOfT);
    if (otherTypers.Contains (typeOfU))
      return (U) Activator.CreateInstance (typeOfU, enumerable)!;

    System.Type[] immutableTypes = ImmutableTypes<T> (typeOfT);
    if (immutableTypes.Contains (typeOfU))
    {
      object instance = null!;
      if (immutableTypes [0] == typeOfU)
        instance = ImmutableArray.CreateRange (enumerable);
      else if (immutableTypes [1] == typeOfU)
        instance = ImmutableHashSet.CreateRange (enumerable);
      else if (immutableTypes [2] == typeOfU)
        instance = ImmutableList.CreateRange (enumerable);
      else if (immutableTypes [3] == typeOfU)
        instance = ImmutableQueue.CreateRange (enumerable);
      else if (immutableTypes [4] == typeOfU)
        instance = ImmutableSortedSet.CreateRange (enumerable);
      else if (immutableTypes [5] == typeOfU)
        instance = ImmutableStack.CreateRange (enumerable);

      return (U) instance;
    }

    throw new ArgumentRangeExceptionC<System.Type>
    (
      paramName: null,
      actualValue: typeOfU,
      specialInfo: typeOfU.FullName,
      inclusiveMin: null,
      inclusiveMax: null,
      valid: immutableTypes.Concat (otherTypers).ToArray (immutableTypes.Length + otherTypers.Length),
      invalid: null
    );
  }
#nullable restore

  static System.Type [] OtherTypes<T> ( System.Type typeOfT )
  {
    if (otherTypes.TryGetValue (typeOfT, out System.Type [] values))
      return values;

    values = new []
    {
          typeof(T[]),
          typeof(List<T>),
          typeof(HashSet<T>),
          typeof(LinkedList<T>),
          typeof(Queue<T>),
          typeof(SortedSet<T>),
          typeof(Stack<T>),
          typeof(ConcurrentBag<T>),
          typeof(ConcurrentQueue<T>),
          typeof(ConcurrentStack<T>),
          typeof(Collection<T>),
          typeof(ObservableCollection<T>),
      };

    _ = otherTypes.TryAdd (typeOfT, values);

    return values;
  }

  static System.Type [] ImmutableTypes<T> ( System.Type typeOfT )
  {

    if (immutableTypes.TryGetValue (typeOfT, out System.Type [] values))
      return values;

    values = new []
    {
        typeof (ImmutableArray<T>),
        typeof (ImmutableHashSet<T>),
        typeof (ImmutableList<T>),
        typeof (ImmutableQueue<T>),
        typeof (ImmutableSortedSet<T>),
        typeof (ImmutableStack<T>),
      };

    _ = immutableTypes.TryAdd (typeOfT, values);

    return values;
  }
}

