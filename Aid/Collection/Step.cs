using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Software9119.Aid.Collection
{

  /// <summary>
  /// Index type with homogenic step size.
  /// </summary>
  [DebuggerDisplay ("(size {size}, value {value})")]
  public struct Step : IEquatable<Step>
  {
    public readonly int Size;
    int value;

    /// <summary>
    /// Constructor with initial value parameter.
    /// </summary>
    /// <param name="value">Value to start on.</param>
    /// <param name="size">Step size.</param>
    public Step ( int size, int value ) : this (size) => this.value = value;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="size">Step size.</param>
    public Step ( int size )
    {
      if ( size == 0 )
        throw new ArgumentOutOfRangeException (nameof (size), $"Cannot make zero-sized steps!");

      Size = size;
      value = 0;
    }

    /// <summary>
    /// Provides <see cref="int"/> representation of <see cref="Step"/> instance.
    /// </summary>    
    public int ToInt32 () => value;

    /// <summary>
    /// See <see cref="ToInt32"/>.
    /// </summary>
    /// <param name="s">Step to cast.</param>
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static implicit operator int ( Step s ) => s.value;

    /// <summary>
    /// See <see cref="Increment()"/>.
    /// </summary>    
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static Step operator ++ ( Step s )
    {
      s.Increment ();
      return s;
    }

    /// <summary>
    /// See <see cref="Decrement()"/>.
    /// </summary>    
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static Step operator -- ( Step s )
    {
      s.Decrement ();
      return s;
    }

    /// <summary>
    /// See <see cref="Add(int)"/>.
    /// </summary>
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static Step operator + ( Step s, int i )
    {
      s.Add (i);
      return s;
    }

    /// <summary>
    /// See <see cref="Subtract(int)"/>.
    /// </summary>    
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static Step operator - ( Step s, int i )
    {
      s.Subtract (i);
      return s;
    }

    /// <summary>
    /// Increments <see cref="Step"/> instance by its step size.
    /// </summary>
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public void Increment () => value += Size;

    /// <summary>
    /// Decrements <see cref="Step"/> instance by its step size.
    /// </summary>    
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public void Decrement () => value -= Size;

    /// <summary>
    /// Provides consumer with ability to increment with arbitrary step size.
    /// </summary>    
    /// <param name="heterogenicStep">Custom step size.</param>    
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public void Add ( int heterogenicStep ) => value += heterogenicStep;

    /// <summary>
    /// Provides consumer with ability to decrement with arbitrary step size.
    /// </summary>    
    /// <param name="heterogenicStep">Custom step size.</param>    
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public void Subtract ( int heterogenicStep ) => value -= heterogenicStep;

    /// <summary>
    /// Equality comparison implementation.
    /// </summary>
    /// <param name="obj">Any object.</param>
    /// <returns>Comparison boolean result.</returns>
    public override bool Equals ( object obj )
    {
      return obj is Step step && Equals (step);
    }

    /// <summary>
    /// Equality comparison implementation.
    /// </summary>
    /// <param name="other">Another <see cref="Step"/>.</param>
    /// <returns>Comparison boolean result.</returns>
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public bool Equals ( Step other ) => this == other;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public override int GetHashCode () => $"{Size}{value}".GetHashCode (StringComparison.InvariantCultureIgnoreCase);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Equality operator.
    /// </summary>    
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static bool operator == ( Step one, Step another ) => one.Size == another.Size && one.value == another.value;

    /// <summary>
    /// Inequality operator.
    /// </summary>    
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static bool operator != ( Step one, Step another ) => !(one == another);
  }
}
