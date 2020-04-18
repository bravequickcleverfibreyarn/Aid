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
      Assert.IsNull(ObjectAid.NullOrResult(null, (string str) => str));
    }

    [TestMethod]
    public void NullOrResult_ValueProvided_ReturnsFunctionResult()
    {
      Func<string, string> func = str => str.Substring(2);
      string value = "XYZ";

      Assert.AreEqual(func(value), ObjectAid.NullOrResult(value, func));
    }

    [TestMethod]
    public void NullOrResult_NullFunc_ThrowsArgNullException()
    {
      Assert.ThrowsException<ArgumentNullException>(() => ObjectAid.NullOrResult<string, object>(null, null));
    }

    // NullableOrResult tests

    [TestMethod]
    public void NullableOrResult_NullProvided_ReturnsNullable()
    {
      Assert.AreEqual(default(char?), ObjectAid.NullableOrResult(null, (string str) => str[0]));
    }

    [TestMethod]
    public void NullableOrResult_ValueProvided_ReturnsFunctionResult()
    {
      Func<string, char> func = str => str[1];
      string value = "XYZ";

      Assert.AreEqual(func(value), ObjectAid.NullableOrResult(value, func));
    }

    [TestMethod]
    public void NullableOrResult_NullFunc_ThrowsArgNullException()
    {
      Assert.ThrowsException<ArgumentNullException>(() => ObjectAid.NullableOrResult<string, int>(null, null));
    }
  }
}