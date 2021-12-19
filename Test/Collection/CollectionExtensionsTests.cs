using Software9119.Aid.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

using _Enumerable = System.Linq.Enumerable;

namespace Test.Collection
{
  [TestClass]
  public class CollectionExtensionsTests
  {
    // ToIList tests

    [TestMethod]
    public void ToIList_ProvidedWithIEnumerableOfT_ReturnsListOfT()
    {
      IEnumerable<char> iEnumerableOfChar = _Enumerable.Range(65, 91).Select(n => (char)n);
      IList<char> iListOfChar = iEnumerableOfChar.ToIList();

      Assert.IsTrue(iListOfChar is List<char>);
    }

    [TestMethod]
    public void ToIList_ProvidedWithICollectionOfT_ReturnsTArray()
    {
      IEnumerable<int> iEnumerableOfInt = new TestCollection<int>(_Enumerable.Range(65, 91).ToList());
      IList<int> iListOfInt = iEnumerableOfInt.ToIList();

      Assert.IsTrue(iListOfInt is int[]);
    }

    [TestMethod]
    public void ToIList_ProvidedWithIListOfT_ReturnsIListOfT()
    {
      IEnumerable<int> iEnumerableOfInt = new TestList<int>();
      IList<int> iListOfInt = iEnumerableOfInt.ToIList();

      Assert.IsTrue(iListOfInt is TestList<int>);
    }

    [TestMethod]
    public void ToIList_ProvidedWithNullExpectsDefault_ReturnsNull()
    {
      Assert.IsNull(((IEnumerable<int>)null).ToIList());
    }


    [TestMethod]
    public void ToIList_ProvidedWithNullExpectsNull_ReturnsNull()
    {
      Assert.IsNull(((IEnumerable<int>)null).ToIList(false));
    }

    [TestMethod]
    public void ToIList_ProvidedWithNullExpectsEmpty_ReturnsEmptyArray()
    {
      IList<int> iListOfInt = ((IEnumerable<int>)null).ToIList(true);

      Assert.IsTrue(iListOfInt is int[]);
      Assert.IsTrue(iListOfInt.Count == 0);
    }
    
    // ToReadOnlyCollection tests

    [TestMethod]
    public void ToReadOnlyCollection_ProvidedWithNullExpectsDefault_ReturnsNull()
    {
      Assert.IsNull(((IEnumerable<string>)null).ToReadOnlyCollection());
    }

    [TestMethod]
    public void ToReadOnlyCollection_ProvidedWithNullExpectsNull_ReturnsNull()
    {
      Assert.IsNull(((IEnumerable<string>)null).ToReadOnlyCollection(false));
    }

    [TestMethod]
    public void ToReadOnlyCollection_ProvidedWithNullExpectsEmpty_ReturnsEmpty()
    {
      Assert.AreEqual(((IEnumerable<string>)null).ToReadOnlyCollection(true).Count, 0);
    }


    [TestMethod]
    public void ToReadOnlyCollection_ProvidedWithIEnumerableOfT_ReturnsROCollection()
    {
      IEnumerable<int> enumerable = _Enumerable.Range(0, 2);
      Assert.IsTrue(enumerable.SequenceEqual(enumerable.ToReadOnlyCollection(true)));
    }

    // ToReadOnlyDictionary tests
    // ReadOnlyDictionary<Key, Value> ToReadOnlyDictionary<Source, Key>(this IEnumerable<Source>, Func<Source, Key>, bool emptyForNull)

    [TestMethod]
    public void ToReadOnlyDictionary1_ProvidedWithNullExpectsDefault_ReturnsNull()
    {
      Assert.IsNull(((IEnumerable<string>)null).ToReadOnlyDictionary(s => default(int), false));
    }

    [TestMethod]
    public void ToReadOnlyDictionary1_ProvidedWithNullExpectsNull_ReturnsNull()
    {
      Assert.IsNull(((IEnumerable<string>)null).ToReadOnlyDictionary(s => 0, false));
    }

    [TestMethod]
    public void ToReadOnlyDictionary1_ProvidedWithNullExpectsEmpty_ReturnsEmpty()
    {
      Assert.AreEqual(((IEnumerable<string>)null).ToReadOnlyDictionary(s => 'A', true).Count, 0);
    }


    [TestMethod]
    [DataRow(false)]
    [DataRow(true)]
    [DataRow(null)]
    public void ToReadOnlyDictionary1_ProvidedWithValidCollection_ReturnsRODict(bool? emptyForNull)
    {
      Func<string, char> keySelector = s => s[0];

      string[] collection = new[] { "Hi", "Bye" };
      Dictionary<char, string> referalDict = collection.ToDictionary(keySelector);

      ReadOnlyDictionary<char, string> result;
      if (emptyForNull.HasValue)
      {
        result = collection.ToReadOnlyDictionary(keySelector, emptyForNull.Value);
      }
      else
      {
        result = collection.ToReadOnlyDictionary(keySelector);
      }

      Assert.IsTrue(referalDict.Keys.SequenceEqual(result.Keys));
      Assert.IsTrue(referalDict.Values.SequenceEqual(result.Values));
    }

    // ReadOnlyDictionary<Key, Value> ToReadOnlyDictionary<Source, Key, Value>(this IEnumerable<Source>, Func<Source, Key>, Func<Source, Value>, bool emptyForNull)

    [TestMethod]
    public void ToReadOnlyDictionary2_ProvidedWithNullExpectsDefault_ReturnsNull()
    {
      Assert.IsNull(((IEnumerable<string>)null).ToReadOnlyDictionary(s => default(int), s => default(string), false));
    }

    [TestMethod]
    public void ToReadOnlyDictionary2_ProvidedWithNullExpectsNull_ReturnsNull()
    {
      Assert.IsNull(((IEnumerable<string>)null).ToReadOnlyDictionary(s => 0, s => 1, false));
    }

    [TestMethod]
    public void ToReadOnlyDictionary2_ProvidedWithNullExpectsEmpty_ReturnsEmpty()
    {
      Assert.AreEqual(((IEnumerable<string>)null).ToReadOnlyDictionary(s => 'A', s => "B", true).Count, 0);
    }
    
    [TestMethod]
    [DataRow(false)]
    [DataRow(true)]
    [DataRow(null)]
    public void ToReadOnlyDictionary2_ProvidedWithValidCollection_ReturnsRODict(bool? emptyForNull)
    {
      Func<string, char> keySelector = s => s[0];
      Func<string, string> valueSelector = s => s[1] + s;

      string[] collection = new[] { "Hi", "Bye" };
      Dictionary<char, string> referalDict = collection.ToDictionary(keySelector, valueSelector);

      ReadOnlyDictionary<char, string> result;
      if (emptyForNull.HasValue)
      {
        result = collection.ToReadOnlyDictionary(keySelector, valueSelector, emptyForNull.Value);
      }
      else
      {
        result = collection.ToReadOnlyDictionary(keySelector, valueSelector);
      }

      Assert.IsTrue(referalDict.Keys.SequenceEqual(result.Keys));
      Assert.IsTrue(referalDict.Values.SequenceEqual(result.Values));
    }

    // AsReadOnlyDictionary tests

    [TestMethod]    
    public void AsReadOnlyDictionary_ProvidedWithNullExpectsDefault_ReturnsNull()
    {
      Assert.IsNull(((Dictionary<string, int>)null).AsReadOnlyDictionary());
    }

    [TestMethod]
    public void AsReadOnlyDictionary_ProvidedWithNullExpectsNull_ReturnsNull()
    {
      Assert.IsNull(((Dictionary<string, int>)null).AsReadOnlyDictionary(false));
    }

    [TestMethod]
    public void AsReadOnlyDictionary_ProvidedWithNullExpectsEmpty_ReturnsEmpty()
    {
      Assert.AreEqual(((Dictionary<string, int>)null).AsReadOnlyDictionary(true).Count, 0);      
    }

    [TestMethod]
    public void AsReadOnlyDictionary_ProvidedWithValidDict_ReturnsRODict()
    {
      var referalDict = new Dictionary<string, int>
      {
        ["one"] = 1,
        ["two"] = 2,
      };

      ReadOnlyDictionary<string, int> roDict = referalDict.AsReadOnlyDictionary();

      Assert.IsTrue(referalDict.Keys.SequenceEqual(roDict.Keys));
      Assert.IsTrue(referalDict.Values.SequenceEqual(roDict.Values));
    }

    #region Test Classes

    class TestCollection<T> : ICollection<T>
    {

      readonly List<T> source;
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

    #endregion

  }
}