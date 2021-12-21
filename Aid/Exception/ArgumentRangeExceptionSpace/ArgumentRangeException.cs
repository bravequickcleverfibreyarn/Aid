using System;
using System.Collections;
using System.Linq;

namespace Software9119.Aid.Exception;

abstract public class ArgumentRangeException : ArgumentOutOfRangeException
{
  const string
    minValue      = "RangeInfo-MinimumInclusiveValue",
    maxValue      = "RangeInfo-MaximumInclusiveValue",
    validValues   = "RangeInfo-ValidValues",
    invalidValues = "RangeInfo-InvalidValues",
    special       = "RangeInfo-SpecialInfo";

  protected ArgumentRangeException
   (
     string paramName,
     object actualValue,
     string specialInfo,
     object inclusiveMin,
     object inclusiveMax,
     IEnumerable valid,
     IEnumerable invalid
   )
  : base (paramName, actualValue, null)
  {

    Set (inclusiveMin, minValue);
    Set (inclusiveMax, maxValue);
    Set (valid, validValues);
    Set (invalid, invalidValues);
    Set (specialInfo, special);

    void Set ( object what, string where )
    {
      if (what is not null)
        Data [where] = what;
    }
  }

  bool Value ( string which, out object value )
  {
    if (Data.Contains (which))
    {
      value = Data [which];
      return true;
    }

    value = null;
    return false;
  }

  protected bool GetValid<T> ( out T valid )
  where T : IEnumerable
  {
    if (Value (validValues, out object value))
    {
      valid = (T) value;
      return true;
    }

    valid = default;
    return false;
  }

  protected bool GetInvalid<T> ( out T invalid )
  where T : IEnumerable
  {
    if (Value (invalidValues, out object value))
    {
      invalid = (T) value;
      return true;
    }

    invalid = default;
    return false;
  }

  protected bool GetMin<T> ( out T min )
  {
    if (Value (minValue, out object value))
    {
      min = (T) value;
      return true;
    }

    min = default;
    return false;
  }

  protected bool GetMax<T> ( out T max )
  {
    if (Value (maxValue, out object value))
    {
      max = (T) value;
      return true;
    }

    max = default;
    return false;
  }

  override public string Message
  {
    get
    {
      string msg = $"Invalid value – {Data [special] ?? ActualValue}!";

      if (GetMin (out object min))
        Add ("Min", min);

      if (GetMax (out object max))
        Add ("Max", max);

      if (GetValid (out IEnumerable valid))
        AddEnumerable ("Valid", valid);

      if (GetInvalid (out IEnumerable invalid))
        AddEnumerable ("Invalid", invalid);

      return msg.TrimEnd ('|');

      void AddEnumerable ( string name, IEnumerable enumerable )
      => Add (name, string.Join (", ", enumerable.Cast<object> ()));

      void Add ( string name, object value )
      => msg += $" {name}: {value}|";
    }
  }

  override public string ToString () => Message;
}
