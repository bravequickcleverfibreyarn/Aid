using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Exception;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Test.Exception;

[TestClass]
public class ArgumentRangeExceptionSTests
{
  [TestMethod]
  public void DataPassedToCtorAreThoseReturnByProperties___SomeValues ()
  {
    const string paramName = "badParam";
    const int
      actualValue   = 1,
      inclusiveMin  = int.MinValue,
      inclusiveMax  = int.MaxValue;

    IReadOnlyList<int>
      valid     = new [] { 1, 2 },
      invalid   = new [] { 3, 4 };

    ArgumentRangeExceptionS<int> exception = new
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
    const int actualValue = 0;

    ArgumentRangeExceptionS<int> exception = new
    (
      paramName: null,
      actualValue: actualValue,
      specialInfo: null,
      inclusiveMin:  null,
      inclusiveMax:null,
      valid: null,
      invalid: null
    );

    Assert.AreEqual (null, exception.ParamName);
    Assert.AreEqual (actualValue, exception.ActualValue);
    Assert.AreEqual (null, exception.Min);
    Assert.AreEqual (null, exception.Max);
    Assert.AreEqual (null, exception.Valid);
    Assert.AreEqual (null, exception.Invalid);
  }

  [TestMethod]
  public void Message___SpecialInfoHasPrecendenceOverActualValue ()
  {
    const HttpStatusCode actualValue = (HttpStatusCode) 5_133_278;

    ArgumentRangeExceptionS<HttpStatusCode> exception = new
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

    static bool ContainsActualValue ( string message )
    {
      return message.Contains
      (
        ((int) actualValue).ToString (CultureInfo.InvariantCulture),
        StringComparison.Ordinal
      );
    }
  }
}
