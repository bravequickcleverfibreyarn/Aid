using System.Collections.Generic;

namespace Software9119.Aid.Exception;

#nullable enable

public class ArgumentRangeExceptionS<T> : ArgumentRangeException
where T : struct
{
  public ArgumentRangeExceptionS
  (
    string? paramName,
    T actualValue,
    string? specialInfo,
    T? inclusiveMin,
    T? inclusiveMax,
    IReadOnlyCollection<T>? valid,
    IReadOnlyCollection<T>? invalid
  )
  : base
  (
      paramName: paramName,
      actualValue: actualValue,
      specialInfo: specialInfo,
      inclusiveMin: inclusiveMin,
      inclusiveMax: inclusiveMax,
      valid: valid,
      invalid: invalid
  )
  { }

  public IReadOnlyCollection<T>? Valid
  {
    get
    {
      _ = GetValid (out IReadOnlyCollection<T>? value);
      return value;
    }
  }

  public IReadOnlyCollection<T>? Invalid
  {
    get
    {
      _ = GetInvalid (out IReadOnlyCollection<T>? value);
      return value;
    }
  }

  public T? Max
  {
    get
    {
      _ = GetMax (out T? value);
      return value;
    }
  }

  public T? Min
  {
    get
    {
      _ = GetMin (out T? value);
      return value;
    }
  }
}

#nullable disable