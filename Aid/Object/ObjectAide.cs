using System;

namespace Software9119.Aid.Object;

static public class ObjectAide
{

#nullable enable

  /// <returns>
  /// <see langword="null"/> if <paramref name="t"/> is <see langword="null"/>. Else <paramref name="func"/> result on <paramref name="t"/>.
  /// </returns>        
  /// <exception cref="ArgumentNullException">When <paramref name="func"/> is <see langword="null"/>.</exception>
  static public U? NullOrResult<T, U> ( T? t, Func<T?, U> func )
  where T : class
  where U : class
  => (U?) NullOrResultCore (t, func);

  /// <returns>
  /// <see cref="Nullable{U}"/> if <paramref name="t"/> is <see langword="null"/>. Else <paramref name="func"/> result on <paramref name="t"/>.
  /// </returns>  
  /// <exception cref="ArgumentNullException">When <paramref name="func"/> is <see langword="null"/>.</exception>
  static public U? NullableOrResult<T, U> ( T? t, Func<T?, U> func )
  where T : class
  where U : struct
  => (U?) NullOrResultCore (t, func);

#nullable disable

  static object NullOrResultCore<T, U> ( T t, Func<T, U> func )
  {
    if (func.IsNull ())
      throw new ArgumentNullException (nameof (func));

    return t.IsNull () ? null : func (t);
  }

#nullable enable

  /// <summary>
  /// Provides <see langword="null"/> safe equality check.
  /// </summary>
  /// <returns><see langword="false"/> if <paramref name="one"/> is <see langword="null"/>. Otherwise result of <see cref="object.Equals(object?)"/>.</returns>
  static public bool Matches<T> ( T? one, T? another )
  where T : class
  => one is not null && one.Equals (another);

  /// <summary>
  /// Provides <see langword="null"/> safe equality check.
  /// </summary>
  /// <returns><see langword="false"/> if <paramref name="one"/> is <see langword="null"/>. Otherwise result of <see cref="ValueType.Equals(object?)"/>.</returns>
  static public bool Matches<T> ( T? one, T? another )
  where T : struct
  => one is not null && one.Value.Equals (another);

#nullable disable
}
