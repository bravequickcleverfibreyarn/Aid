using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Object;

using System;

namespace Test.Object
{
  [TestClass]
  public class ObjectAidTests
  {
    // NullOrResult tests

    [TestMethod]
    public void NullOrResult_NullProvided_ReturnsNull()
    {
      Assert.IsNull(ObjectAide.NullOrResult(null, (string str) => str));
    }

    [TestMethod]
    public void NullOrResult_ValueProvided_ReturnsFunctionResult()
    {
      Func<string, string> func = str => str.Substring(2);
      string value = "XYZ";

      Assert.AreEqual(func(value), ObjectAide.NullOrResult(value, func));
    }

    [TestMethod]
    public void NullOrResult_NullFunc_ThrowsArgNullException()
    {
      Assert.ThrowsException<ArgumentNullException>(() => ObjectAide.NullOrResult<string, object>(null, null));
    }

    // NullableOrResult tests

    [TestMethod]
    public void NullableOrResult_NullProvided_ReturnsNullable()
    {
      Assert.AreEqual(default(char?), ObjectAide.NullableOrResult(null, (string str) => str[0]));
    }

    [TestMethod]
    public void NullableOrResult_ValueProvided_ReturnsFunctionResult()
    {
      Func<string, char> func = str => str[1];
      string value = "XYZ";

      Assert.AreEqual(func(value), ObjectAide.NullableOrResult(value, func));
    }

    [TestMethod]
    public void NullableOrResult_NullFunc_ThrowsArgNullException()
    {
      Assert.ThrowsException<ArgumentNullException>(() => ObjectAide.NullableOrResult<string, int>(null, null));
    }

    [TestMethod]
    [DataRow(null, null, false)]
    [DataRow(1, null, false)]
    [DataRow(null, 1, false)]
    [DataRow(1L, 1, false)]
    [DataRow(1L, 1L, true)]
    [DataRow("Test", "Failure", false)]
    [DataRow("Test", "Test", true)]
    public void Matches_TestDataProvided_MeetExpectations(object left, object right, bool expectation)
    {
      Assert.AreEqual(expectation, ObjectAide.Matches(left, right));
    }
  }
}