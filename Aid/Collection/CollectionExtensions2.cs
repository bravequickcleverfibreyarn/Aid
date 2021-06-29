using Software9119.Aid.Enumerable;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace Software9119.Aid.Collection
{
  static public partial class CollectionExtensions
  {
    /// <summary>
    /// Helper to cast <see cref="IEnumerable{T}"/> or create collection from <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T"><see cref="IEnumerable{T}"/> T type.</typeparam>
    /// <typeparam name="U">Desired as/to type.</typeparam>    
    static public U AsOrTo<T, U>(this IEnumerable<T> enumerable, bool emptyForNull = false)
    {

      IReadOnlyDictionary<System.Type, Func<IEnumerable<T>, object>> immutableTypesMap = new Dictionary<System.Type, Func<IEnumerable<T>, object>>
      {
        [typeof(ImmutableArray<T>)] = __enumerable => ImmutableArray.CreateRange(__enumerable),
        [typeof(ImmutableHashSet<T>)] = __enumerable => ImmutableHashSet.CreateRange(__enumerable),
        [typeof(ImmutableList<T>)] = __enumerable => ImmutableList.CreateRange(__enumerable),
        [typeof(ImmutableQueue<T>)] = __enumerable => ImmutableQueue.CreateRange(__enumerable),
        [typeof(ImmutableSortedSet<T>)] = __enumerable => ImmutableSortedSet.CreateRange(__enumerable),
        [typeof(ImmutableStack<T>)] = __enumerable => ImmutableStack.CreateRange(__enumerable),
      };

      IReadOnlyList<System.Type> otherTypers = new[]
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

      IReadOnlyList<System.Type> supportedTypes = immutableTypesMap.Keys.Concat(otherTypers).ToArray(immutableTypesMap.Count + otherTypers.Count);
      otherTypers = null;

      System.Type typeOfU = typeof(U);
      if (!supportedTypes.Contains(typeOfU))
      {
        throw new InvalidOperationException($"Unsupported type – {typeOfU.AssemblyQualifiedName}!");
      }

      if (enumerable != null && enumerable.GetType() == typeOfU)
      {
        return (U)enumerable;
      }

      object instance = null; // Just initialization, no logic.

      if (enumerable == null && emptyForNull)
      {
        enumerable = Array.Empty<T>();

        if (typeOfU == typeof(T[]))
        {
          return (U)enumerable;
        }
      }

      if (immutableTypesMap.TryGetValue(typeOfU, out Func<IEnumerable<T>, object> creator))
      {
        instance = creator(enumerable);
      }
      else if (typeOfU == typeof(T[]))
      {
        return (U)(object)enumerable.ToArray();
      }
      else
      {
        instance = Activator.CreateInstance(typeOfU, enumerable);
      }

      return (U)instance;
    }
  }
}
