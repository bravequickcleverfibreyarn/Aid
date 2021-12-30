using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Enumerable;

using System;
using System.Collections.Generic;
using System.Linq;

using _Enumerable = System.Linq.Enumerable;

namespace Test.Enumerable;

[TestClass]
public class EnumerableExtensionsTests
{

  [TestMethod]
  public void ToArray_SomeEnumerable_ReturnsArray ()
  {
    const int count = 10;
    IEnumerable<int> enumerable = _Enumerable.Range(0, count);

    int[] result = enumerable.ToArray(count);

    Assert.AreEqual (typeof (int []), result.GetType ());
    Assert.IsTrue (enumerable.SequenceEqual (result));
  }

  [TestMethod]
  public void ToList_SomeEnumerable_ReturnsList ()
  {
    const int count = 10;
    IEnumerable<int> enumerable = _Enumerable.Range(0, count);

#pragma warning disable IDE0007 // Use implicit type
    List<int> result = enumerable.ToList(count);
#pragma warning restore IDE0007 // Use implicit type

    Assert.AreEqual (typeof (List<int>), result.GetType ());
    Assert.IsTrue (enumerable.SequenceEqual (result));
  }

  [TestMethod]
  public void ToDictionary_SomeEnumerableKeySelector_ReturnsDictionary ()
  {
    IReadOnlyList<string> testData = new[]
    {
      "+Hello",
      "Adiós",
      "Hasta luego",
      "*_Hasta otro día",
      "_Hi"
    };

    Func<string, char> keySelector = x => x[0];

    IReadOnlyDictionary<char, string> referralDict = testData.ToDictionary(keySelector);
    IReadOnlyDictionary<char, string> testDict = testData.ToDictionary(keySelector, testData.Count);

    Assert.AreEqual (typeof (Dictionary<char, string>), testDict.GetType ());
    Assert.IsTrue (referralDict.Keys.SequenceEqual (testDict.Keys));
    Assert.IsTrue (referralDict.Values.SequenceEqual (testDict.Values));
  }

  [TestMethod]
  public void ToDictionary_SomeEnumerableKeySelectorValueSelector_ReturnsDictionary ()
  {
    IReadOnlyList<string> testData = new[]
    {
      "+Hello",
      "Adiós",
      "Hasta luego",
      "*_Hasta otro día",
      "_Hi"
    };

    Func<string, char> keySelector = x => x[0];
    Func<string, char> valueSelector = x => x[^1];

    IReadOnlyDictionary<char, char> referralDict = testData.ToDictionary(keySelector, valueSelector);
    IReadOnlyDictionary<char, char> testDict = testData.ToDictionary(keySelector, valueSelector, testData.Count);

    Assert.AreEqual (typeof (Dictionary<char, char>), testDict.GetType ());
    Assert.IsTrue (referralDict.Keys.SequenceEqual (testDict.Keys));
    Assert.IsTrue (referralDict.Values.SequenceEqual (testDict.Values));
  }
}
