using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Exception;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Exception;

[TestClass]
public class ArgumentRangeExceptionCTests
{
  [TestMethod]
  public void DataPassedToCtorAreThoseReturnByProperties___SomeValues ()
  {
    const string paramName = "badParam";

    const string
      actualValue   = "someUndesiredValue",
      inclusiveMin  = "incMin",
      inclusiveMax  = "incMax";

    IReadOnlyList<string>
      valid     = new [] { "A", "B" },
      invalid   = new [] { "C", "D" };

    ArgumentRangeExceptionC<string> exception = new
    (
      paramName: paramName,
      actualValue: actualValue,
      specialInfo: null,
      inclusiveMin:  inclusiveMin,
      inclusiveMax:inclusiveMax,
      valid: valid,
      invalid: invalid
    );

    Assert.AreEqual (paramName, exception.ParamName);
    Assert.AreEqual (actualValue, exception.ActualValue);
    Assert.AreEqual (inclusiveMin, exception.Min);
    Assert.AreEqual (inclusiveMax, exception.Max);
    Assert.IsTrue (valid.SequenceEqual (exception.Valid));
    Assert.IsTrue (invalid.SequenceEqual (exception.Invalid));
  }

  [TestMethod]
  public void DataPassedToCtorAreThoseReturnByProperties___Nulls ()
  {
    ArgumentRangeExceptionC<string> exception = new
    (
      paramName: null,
      actualValue: null,
      specialInfo: null,
      inclusiveMin:  null,
      inclusiveMax:null,
      valid: null,
      invalid: null
    );

    Assert.AreEqual (null, exception.ParamName);
    Assert.AreEqual (null, exception.ActualValue);
    Assert.AreEqual (null, exception.Min);
    Assert.AreEqual (null, exception.Max);
    Assert.AreEqual (null, exception.Valid);
    Assert.AreEqual (null, exception.Invalid);
  }

  [TestMethod]
  public void Message___SpecialInfoHasPrecendenceOverActualValue ()
  {
    const string actualValue = "someUndesiredValue";

    ArgumentRangeExceptionC<string> exception = new
    (
      paramName: null,
      actualValue: actualValue,
      specialInfo: null,
      inclusiveMin:  null,
      inclusiveMax:null,
      valid: null,
      invalid: null
    );

    Assert.IsTrue (ContainsActualValue (exception.Message));

    const string specialInfo = "VerySpecificRepresentationOfValueOutOfRange";

    exception = new
    (
      paramName: null,
      actualValue: actualValue,
      specialInfo: specialInfo,
      inclusiveMin: null,
      inclusiveMax: null,
      valid: null,
      invalid: null
    );

    string message = exception.Message;

    Assert.IsTrue (message.Contains (specialInfo, StringComparison.Ordinal));
    Assert.IsFalse (ContainsActualValue (message));

    static bool ContainsActualValue ( string message ) => message.Contains (actualValue, StringComparison.Ordinal);
  }
}
