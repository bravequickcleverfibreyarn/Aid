using Software9119.Aid.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
  [TestClass]
  public class CollectionExtensionTests
  {

    [TestMethod]
    public void ToIList_ProvidedWithIEnumerableOfT_ReturnsListOfT()
    {
      IEnumerable<char> iEnumerableOfChar = Enumerable.Range(65, 91).Select(n => (char)n);
      IList<char> iListOfChar = iEnumerableOfChar.ToIList();

      Assert.IsTrue(iListOfChar.GetType() == typeof(List<char>));      
    }

    [TestMethod]
    public void ToIList_ProvidedWithICollectionOfT_ReturnsTArray()
    {
      IEnumerable<int> iEnumerableOfInt = new TestCollection<int>(Enumerable.Range(65, 91).ToList());
      IList<int> iListOfInt = iEnumerableOfInt.ToIList();

      Assert.IsTrue(iListOfInt.GetType() == typeof(int[]));      
    }

    [TestMethod]
    public void ToIList_ProvidedWithIListOfT_ReturnsIListOfT()
    {
      IEnumerable<int> iEnumerableOfInt = new TestList<int>();
      IList<int> iListOfInt = iEnumerableOfInt.ToIList();

      Assert.IsTrue(iListOfInt.GetType() == typeof(TestList<int>));      
    }


    class TestCollection<T> : ICollection<T>
    {

      private List<T> source;
      public TestCollection(List<T> source) => this.source = source;

      public int Count => source.Count;

      public bool IsReadOnly => throw new NotImplementedException();

      public void Add(T item) => throw new NotImplementedException();

      public void Clear() => throw new NotImplementedException();

      public bool Contains(T item) => throw new NotImplementedException();

      public void CopyTo(T[] array, int arrayIndex) => source.CopyTo(array);

      public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

      public bool Remove(T item) => throw new NotImplementedException();

      IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    }

    class TestList<T> : IList<T>
    {

      public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

      public int Count => throw new NotImplementedException();

      public bool IsReadOnly => throw new NotImplementedException();

      public void Add(T item) => throw new NotImplementedException();

      public void Clear() => throw new NotImplementedException();

      public bool Contains(T item) => throw new NotImplementedException();

      public void CopyTo(T[] array, int arrayIndex) => throw new NotImplementedException();

      public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

      public int IndexOf(T item) => throw new NotImplementedException();

      public void Insert(int index, T item) => throw new NotImplementedException();

      public bool Remove(T item) => throw new NotImplementedException();

      public void RemoveAt(int index) => throw new NotImplementedException();

      IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    }

  }
}