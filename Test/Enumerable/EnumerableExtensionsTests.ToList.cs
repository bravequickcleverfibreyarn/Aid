using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

using _Enumerable = System.Linq.Enumerable;

namespace Test.Enumerable;

[TestClass]
public class EnumerableExtensionsTests_ToList
{
  [TestMethod]
  public void SomeEnumerable__ReturnsList ()
  {
    const int count = 10;
    IEnumerable<int> enumerable = _Enumerable.Range(0, count);

    var result = Software9119.Aid.Enumerable.EnumerableExtensions.ToList (enumerable , count, default(bool));

    Assert.AreEqual (typeof (List<int>), result.GetType ());
    Assert.IsTrue (enumerable.SequenceEqual (result));
  }

  [TestMethod]
  public void NullEnumerableDoesNotWantNull__ThrowsArgumentNullException ()
  {
    _ = Assert.ThrowsException<ArgumentNullException>
    (
      () => Software9119.Aid.Enumerable.EnumerableExtensions.ToList
      (
        (IEnumerable<int>) null,
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
      Software9119.Aid.Enumerable.EnumerableExtensions.ToList
      (
        (IEnumerable<int>) null,
        default (int),
        true
      )
    );
  }
}
