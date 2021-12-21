using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software9119.Aid.Object;

namespace Test.Object;

[TestClass]
public class ObjectExtensionsTests
{
  // IsNull tests

  [TestMethod]
  public void IsNull_ProvidedWithNull_ReturnsTrue ()
  {
    Assert.IsTrue (((object) null).IsNull ());
  }

  [TestMethod]
  public void IsNull_ProvidedWithObject_ReturnsFalse ()
  {
    Assert.IsFalse (new object ().IsNull ());
  }
}
