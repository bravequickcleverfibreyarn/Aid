
using System;
using System.Threading.Tasks;

namespace Software9119.Aid.Concurrency.Unchecked;

/// <summary>
/// Core functionality for <see cref="Concurrency.AsyncAide"/> without parameter checks.
/// </summary>
static public partial class AsyncAide
{
  /// <summary>
  /// Runs provided <paramref name="func"/> on different thread in blocking manner
  /// using <see cref="Task.Run{TResult}(Func{Task{TResult}?})"/>.
  /// </summary>
  static public T RunSync<T> ( Func<Task<T>> func ) => Task.Run (func).GetAwaiter ().GetResult ();

  /// <summary>
  /// Runs provided <paramref name="func"/> on different thread in blocking manner
  /// using <see cref="Task.Run(Func{Task?})"/>.
  /// </summary>
  static public void RunSync ( Func<Task> func ) => Task.Run (func).GetAwaiter ().GetResult ();
}
