using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Collection;
using Software9119.Aid.Exception;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

using _Enumerable = System.Linq.Enumerable;

namespace Test.Collection;

[TestClass]
public class CollectionExtensionsTests2
{
  #region NullEnumerableWantsEmpty_GetsEmpty

  [TestMethod]
  public void AsOrTo_ImmutableArray_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ImmutableArray<int> result = ((int[])null).AsOrTo<int, ImmutableArray<int>>(emptyForNull: true);

    Assert.AreEqual (typeof (ImmutableArray<int>), result.GetType ());
    Assert.IsTrue (result.IsEmpty);
  }

  [TestMethod]
  public void AsOrTo_ImmutableHashSet_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ImmutableHashSet<string> result = ((string[])null).AsOrTo<string, ImmutableHashSet<string>>(emptyForNull: true);

    Assert.AreEqual (typeof (ImmutableHashSet<string>), result.GetType ());
    Assert.IsTrue (result.IsEmpty);
  }

  [TestMethod]
  public void AsOrTo_ImmutableList_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ImmutableList<string> result = ((string[])null).AsOrTo<string, ImmutableList<string>>(emptyForNull: true);

    Assert.AreEqual (typeof (ImmutableList<string>), result.GetType ());
    Assert.IsTrue (result.IsEmpty);
  }

  [TestMethod]
  public void AsOrTo_ImmutableQueue_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ImmutableQueue<string> result = ((string[])null).AsOrTo<string, ImmutableQueue<string>>(emptyForNull: true);

    Assert.AreEqual (typeof (ImmutableQueue<string>), result.GetType ());
    Assert.IsTrue (result.IsEmpty);
  }

  [TestMethod]
  public void AsOrTo_ImmutableSortedSet_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ImmutableSortedSet<string> result = ((string[])null).AsOrTo<string, ImmutableSortedSet<string>>(emptyForNull: true);

    Assert.AreEqual (typeof (ImmutableSortedSet<string>), result.GetType ());
    Assert.IsTrue (result.IsEmpty);
  }

  [TestMethod]
  public void AsOrTo_ImmutableStack_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ImmutableStack<string> result = ((string[])null).AsOrTo<string, ImmutableStack<string>>(emptyForNull: true);

    Assert.AreEqual (typeof (ImmutableStack<string>), result.GetType ());
    Assert.IsTrue (result.IsEmpty);
  }

  [TestMethod]
  public void AsOrTo_ArrayOfT_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    DateTime [] result = ((DateTime[])null).AsOrTo<DateTime, DateTime[]>(emptyForNull: true);

    Assert.AreEqual (typeof (DateTime []), result.GetType ());
    Assert.AreEqual (0, result.Length);
  }

  [TestMethod]
  public void AsOrTo_List_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    List<DateTime> result = ((DateTime[])null).AsOrTo<DateTime, List<DateTime>>(emptyForNull: true);

    Assert.AreEqual (typeof (List<DateTime>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_HashSet_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    HashSet<TimeSpan> result = ((TimeSpan[])null).AsOrTo<TimeSpan, HashSet<TimeSpan>>(emptyForNull: true);

    Assert.AreEqual (typeof (HashSet<TimeSpan>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_LinkedList_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    LinkedList<TimeSpan> result = ((TimeSpan[])null).AsOrTo<TimeSpan, LinkedList<TimeSpan>>(emptyForNull: true);

    Assert.AreEqual (typeof (LinkedList<TimeSpan>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_QueueOfT_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    Queue<TimeSpan> result = ((TimeSpan[])null).AsOrTo<TimeSpan, Queue<TimeSpan>>(emptyForNull: true);

    Assert.AreEqual (typeof (Queue<TimeSpan>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_SortedSet_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    SortedSet<TimeSpan> result = ((TimeSpan[])null).AsOrTo<TimeSpan, SortedSet<TimeSpan>>(emptyForNull: true);

    Assert.AreEqual (typeof (SortedSet<TimeSpan>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_StackOfT_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    Stack<long> result = ((long[])null).AsOrTo<long, Stack<long>>(emptyForNull: true);

    Assert.AreEqual (typeof (Stack<long>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_ConcurrentBag_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ConcurrentBag<long> result = ((long[])null).AsOrTo<long, ConcurrentBag<long>>(emptyForNull: true);

    Assert.AreEqual (typeof (ConcurrentBag<long>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_ConcurrentQueue_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ConcurrentQueue<long> result = ((long[])null).AsOrTo<long, ConcurrentQueue<long>>(emptyForNull: true);

    Assert.AreEqual (typeof (ConcurrentQueue<long>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_ConcurrentStack_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ConcurrentStack<decimal> result = ((decimal[])null).AsOrTo<decimal, ConcurrentStack<decimal>>(emptyForNull: true);

    Assert.AreEqual (typeof (ConcurrentStack<decimal>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_Collection_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    Collection<decimal> result = ((decimal[])null).AsOrTo<decimal, Collection<decimal>>(emptyForNull: true);

    Assert.AreEqual (typeof (Collection<decimal>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  [TestMethod]
  public void AsOrTo_ObservableCollection_NullEnumerableWantsEmpty_GetsEmpty ()
  {
    ObservableCollection<decimal> result = ((decimal[])null).AsOrTo<decimal, ObservableCollection<decimal>>(emptyForNull: true);

    Assert.AreEqual (typeof (ObservableCollection<decimal>), result.GetType ());
    Assert.AreEqual (0, result.Count);
  }

  #endregion

  #region NullEnumerable_Throws

  [TestMethod]
  public void AsOrTo_Any_NullEnumerable_ThrowsArgumentNullException ()
  {
    _ = Assert.ThrowsException<ArgumentNullException>
   (
     () => ((object []) null).AsOrTo<object, object> ()
    );
  }

  #endregion

  #region SomeEnumerable_ReturnsToCollection

  [TestMethod]
  public void AsOrTo_ImmutableArray_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ImmutableArray<int> result = collection.AsOrTo<int, ImmutableArray<int>>();

    Assert.AreEqual (typeof (ImmutableArray<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableHashSet_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ImmutableHashSet<int> result = collection.AsOrTo<int, ImmutableHashSet<int>>();

    Assert.AreEqual (typeof (ImmutableHashSet<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableList_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ImmutableList<int> result = collection.AsOrTo<int, ImmutableList<int>>();

    Assert.AreEqual (typeof (ImmutableList<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableQueue_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ImmutableQueue<int> result = collection.AsOrTo<int, ImmutableQueue<int>>();

    Assert.AreEqual (typeof (ImmutableQueue<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableSortedSet_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ImmutableSortedSet<int> result = collection.AsOrTo<int, ImmutableSortedSet<int>>();

    Assert.AreEqual (typeof (ImmutableSortedSet<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableStack_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ImmutableStack<int> result = collection.AsOrTo<int, ImmutableStack<int>>();

    Assert.AreEqual (typeof (ImmutableStack<int>), result.GetType ());
    Assert.IsTrue (collection.All (x => result.Contains (x)));
    Assert.IsTrue (result.All (x => collection.Contains (x)));
  }

  [TestMethod]
  public void AsOrTo_ArrayOfT_SomeEnumerable_ReturnsToCollection ()
  {
    IEnumerable<int> collection = _Enumerable.Range(1, 3);
    int [] result = collection.AsOrTo<int, int[]>();

    Assert.AreEqual (typeof (int []), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_List_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    List<int> result = collection.AsOrTo<int, List<int>>();

    Assert.AreEqual (typeof (List<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_HashSet_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    HashSet<int> result = collection.AsOrTo<int, HashSet<int>>();

    Assert.AreEqual (typeof (HashSet<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_LinkedList_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    LinkedList<int> result = collection.AsOrTo<int, LinkedList<int>>();

    Assert.AreEqual (typeof (LinkedList<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_QueueOfT_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    Queue<int> result = collection.AsOrTo<int, Queue<int>>();

    Assert.AreEqual (typeof (Queue<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_SortedSet_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    SortedSet<int> result = collection.AsOrTo<int, SortedSet<int>>();

    Assert.AreEqual (typeof (SortedSet<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_StackOfT_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    Stack<int> result = collection.AsOrTo<int, Stack<int>>();

    Assert.AreEqual (typeof (Stack<int>), result.GetType ());
    Assert.AreEqual (collection.Length, result.Count);
    Assert.IsTrue (collection.All (x => result.Contains (x)));
  }

  [TestMethod]
  public void AsOrTo_ConcurrentBag_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ConcurrentBag<int> result = collection.AsOrTo<int, ConcurrentBag<int>>();

    Assert.AreEqual (typeof (ConcurrentBag<int>), result.GetType ());
    Assert.AreEqual (collection.Length, result.Count);
    Assert.IsTrue (collection.All (x => result.Contains (x)));
  }

  [TestMethod]
  public void AsOrTo_ConcurrentQueue_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ConcurrentQueue<int> result = collection.AsOrTo<int, ConcurrentQueue<int>>();

    Assert.AreEqual (typeof (ConcurrentQueue<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_ConcurrentStack_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ConcurrentStack<int> result = collection.AsOrTo<int, ConcurrentStack<int>>();

    Assert.AreEqual (typeof (ConcurrentStack<int>), result.GetType ());
    Assert.AreEqual (collection.Length, result.Count);
    Assert.IsTrue (collection.All (x => result.Contains (x)));
  }

  [TestMethod]
  public void AsOrTo_Collection_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    Collection<int> result = collection.AsOrTo<int, Collection<int>>();

    Assert.AreEqual (typeof (Collection<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  [TestMethod]
  public void AsOrTo_ObservableCollection_SomeEnumerable_ReturnsToCollection ()
  {
    int [] collection = new[] { 1, 2, 3 };
    ObservableCollection<int> result = collection.AsOrTo<int, ObservableCollection<int>>();

    Assert.AreEqual (typeof (ObservableCollection<int>), result.GetType ());
    Assert.IsTrue (collection.SequenceEqual (result));
  }

  #endregion

  #region SameEnumerable_ReturnsCast

  [TestMethod]
  public void AsOrTo_ImmutableArray_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> sameEnumerable = ImmutableArray.CreateRange(new[] { 1, 2, 3 });

    ImmutableArray<int> result = sameEnumerable.AsOrTo<int, ImmutableArray<int>>();

    Assert.AreEqual (sameEnumerable, result);
    Assert.AreEqual (sameEnumerable.Count (), result.Length);
    Assert.IsTrue (sameEnumerable.All (x => result.Contains (x)));
  }

  [TestMethod]
  public void AsOrTo_ImmutableHashSet_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> sameEnumerable = ImmutableHashSet.CreateRange(new[] { 1, 2, 3 });

    ImmutableHashSet<int> result = sameEnumerable.AsOrTo<int, ImmutableHashSet<int>>();

    Assert.IsTrue (ReferenceEquals (sameEnumerable, result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableList_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> sameEnumerable = ImmutableList.CreateRange(new[] { 1, 2, 3 });

    ImmutableList<int> result = sameEnumerable.AsOrTo<int, ImmutableList<int>>();

    Assert.IsTrue (ReferenceEquals (sameEnumerable, result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableQueue_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> sameEnumerable = ImmutableQueue.CreateRange(new[] { 1, 2, 3 });

    ImmutableQueue<int> result = sameEnumerable.AsOrTo<int, ImmutableQueue<int>>();

    Assert.IsTrue (ReferenceEquals (sameEnumerable, result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableSortedSet_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> sameEnumerable = ImmutableSortedSet.CreateRange(new[] { 1, 2, 3 });

    ImmutableSortedSet<int> result = sameEnumerable.AsOrTo<int, ImmutableSortedSet<int>>();

    Assert.IsTrue (ReferenceEquals (sameEnumerable, result));
  }

  [TestMethod]
  public void AsOrTo_ImmutableStack_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> sameEnumerable = ImmutableStack.CreateRange(new[] { 1, 2, 3 });

    ImmutableStack<int> result = sameEnumerable.AsOrTo<int, ImmutableStack<int>>();

    Assert.IsTrue (ReferenceEquals (sameEnumerable, result));
  }

  [TestMethod]
  public void AsOrTo_ArrayOfT_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new[] { 1, 2, 3 };
    int [] result = collection.AsOrTo<int, int[]>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_List_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new List<int> { 1, 2, 3 };
    List<int> result = collection.AsOrTo<int, List<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_HashSet_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new HashSet<int>(new[] { 1, 2, 3 });
    HashSet<int> result = collection.AsOrTo<int, HashSet<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_LinkedList_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new LinkedList<int>(new[] { 1, 2, 3 });
    LinkedList<int> result = collection.AsOrTo<int, LinkedList<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_QueueOfT_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new Queue<int>(new[] { 1, 2, 3 });
    Queue<int> result = collection.AsOrTo<int, Queue<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_SortedSet_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new SortedSet<int>(new[] { 1, 2, 3 });
    SortedSet<int> result = collection.AsOrTo<int, SortedSet<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_StackOfT_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new Stack<int>(new[] { 1, 2, 3 });
    Stack<int> result = collection.AsOrTo<int, Stack<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_ConcurrentBag_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new ConcurrentBag<int>(new[] { 1, 2, 3 });
    ConcurrentBag<int> result = collection.AsOrTo<int, ConcurrentBag<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_ConcurrentQueue_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new ConcurrentQueue<int>(new[] { 1, 2, 3 });
    ConcurrentQueue<int> result = collection.AsOrTo<int, ConcurrentQueue<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_ConcurrentStack_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new ConcurrentStack<int>(new[] { 1, 2, 3 });
    ConcurrentStack<int> result = collection.AsOrTo<int, ConcurrentStack<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_Collection_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new Collection<int>(new[] { 1, 2, 3 });
    Collection<int> result = collection.AsOrTo<int, Collection<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  [TestMethod]
  public void AsOrTo_ObservableCollection_SameEnumerable_ReturnsCast ()
  {
    IEnumerable<int> collection = new ObservableCollection<int>(new[] { 1, 2, 3 });
    ObservableCollection<int> result = collection.AsOrTo<int, ObservableCollection<int>>();

    Assert.IsTrue (ReferenceEquals (collection, result));
  }

  #endregion

  #region UnsupportedDestinationType


  [TestMethod]
  public void AsOrTo_UnsupportedDestinationTypeButItIsJustCast_CastProvided ()
  {
    IEnumerable<int> collection = new ReadOnlyCollection<int>(new [] { 1, 2, 3 });
    ReadOnlyCollection<int> cast = collection.AsOrTo<int, ReadOnlyCollection<int>>();

    Assert.AreSame (collection, cast);
  }

  [TestMethod]
  public void AsOrTo_UnsupportedDestinationType_ThrowsArgumentRangeExceptionC ()
  {
    IEnumerable<int> collection = new[] { 1, 2, 3 };
    Action asOrToAction = () => collection.AsOrTo<int, ReadOnlyCollection<int>>();

    ArgumentRangeExceptionC<System.Type> are = Assert.ThrowsException<ArgumentRangeExceptionC<System.Type>>(asOrToAction);

    Assert.AreEqual (typeof (ReadOnlyCollection<int>), are.ActualValue);
    Assert.IsTrue
    (
      are.Valid.SequenceEqual
      (
        new []
        {
            typeof(ImmutableArray<int>),
            typeof(ImmutableHashSet<int>),
            typeof(ImmutableList<int>),
            typeof(ImmutableQueue<int>),
            typeof(ImmutableSortedSet<int>),
            typeof(ImmutableStack<int>),
            typeof(int []),
            typeof(List<int>),
            typeof(HashSet<int>),
            typeof(LinkedList<int>),
            typeof(Queue<int>),
            typeof(SortedSet<int>),
            typeof(Stack<int>),
            typeof(ConcurrentBag<int>),
            typeof(ConcurrentQueue<int>),
            typeof(ConcurrentStack<int>),
            typeof(Collection<int>),
            typeof(ObservableCollection<int>),
        }
      )
    );
  }
  #endregion
}
