using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Enumerable;

[TestClass]
public class EnumerableExtensionsTests_ToDictionary_KeySelector
{

  [TestMethod]
  public void SomeEnumerable__ReturnsDictionary ()
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
    IReadOnlyDictionary<char, string> testDict = Software9119.Aid.Enumerable.EnumerableExtensions.ToDictionary
    (
      testData,
      keySelector,
      testData.Count,
      default(bool)
    );

    Assert.AreEqual (typeof (Dictionary<char, string>), testDict.GetType ());
    Assert.IsTrue (referralDict.Keys.SequenceEqual (testDict.Keys));
    Assert.IsTrue (referralDict.Values.SequenceEqual (testDict.Values));
  }

  [TestMethod]
  public void NullEnumerableDoesNotWantNull__ThrowsArgumentNullException ()
  {
    _ = Assert.ThrowsException<ArgumentNullException>
    (
      () => Software9119.Aid.Enumerable.EnumerableExtensions.ToDictionary
      (
        (IEnumerable<int>)null,
        x => x,
        default (int),
        false
      )
    );
  }

  [TestMethod]
  public void NullEnumerableWantsNull__GetsNull ()
  {
    Assert.AreEqual
    (
      null,
      Software9119.Aid.Enumerable.EnumerableExtensions.ToDictionary
      (
        (IEnumerable<int>) null,
        x => x,
        default (int),
        true
      )
    );
  }

  [TestMethod]
  public void NullKeySelector__ThrowsArgumentNullException ()
  {
    _ = Assert.ThrowsException<ArgumentNullException>
    (
      () => Software9119.Aid.Enumerable.EnumerableExtensions.ToDictionary
      (
        Array.Empty<int> (),
        (Func<int, int>) null,
        default (int),
        default (bool)
      )
    );
  }
}
