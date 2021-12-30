
using System;
using System.Threading.Tasks;

namespace Software9119.Aid.Concurrency;

static public partial class AsyncAide
{
  /// <summary>
  /// Runs provided <paramref name="func"/> on different thread in blocking manner
  /// using <see cref="Task.Run{TResult}(Func{Task{TResult}?})"/>.
  /// </summary>
  /// <exception cref="ArgumentNullException"/>
  static public T RunSync<T> ( Func<Task<T>> func )
  {
    if (func is null)
      throw new ArgumentNullException (nameof (func));

    return Unchecked.AsyncAide.RunSync (func);
  }

  /// <summary>
  /// Runs provided <paramref name="func"/> on different thread in blocking manner
  /// using <see cref="Task.Run(Func{Task?})"/>.
  /// </summary>
  /// <exception cref="ArgumentNullException"/>
  static public void RunSync ( Func<Task> func )
  {
    if (func is null)
      throw new ArgumentNullException (nameof (func));

    Unchecked.AsyncAide.RunSync (func);
  }
}
