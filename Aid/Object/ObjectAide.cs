﻿using System;

namespace Software9119.Aid.Object
{
  static public class ObjectAide
  {
    /// <summary>
    /// Null for null <paramref name="obj"/>. Else <paramref name="func"/> result on <paramref name="obj"/>.
    /// </summary>        
    static public U NullOrResult<T, U>(T obj, Func<T, U> func)
    where T : class
    where U : class
    {
      ThrowNullFunc(func, nameof(func));

      return obj.IsNull() ? null : func(obj);
    }

    /// <summary>
    /// Nullable <typeparamref name="U"/>> for null <paramref name="obj"/>. Else <paramref name="func"/> result on <paramref name="obj"/>.
    /// </summary>  
    static public U? NullableOrResult<T, U>(T obj, Func<T, U> func)
    where T : class
    where U : struct
    {
      ThrowNullFunc(func, nameof(func));

      return obj.IsNull() ? (U?)null : func(obj);
    }

    static void ThrowNullFunc(object func, string paramName)
    {
      if (func.IsNull())
      {
        throw new ArgumentNullException(paramName);
      }
    }

    /// <summary>
    /// Provides null safe equality check.
    /// </summary>    
    /// <returns>False if either of params is null. Otherwise result of <see cref="object.Equals(object, object)"/>.</returns>
    static public bool Matches(object one, object another) => one != null && Equals(one, another);
  }
}