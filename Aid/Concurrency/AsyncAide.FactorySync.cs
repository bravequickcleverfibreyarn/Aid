
using System;
using System.Threading.Tasks;

namespace Software9119.Aid.Concurrency;

static public partial class AsyncAide
{
  /// <summary>
  /// Runs provided functions on different thread in blocking manner using settings
  /// provided to <see cref="FactorySync(TaskCreationOptions, TaskContinuationOptions, TaskScheduler)"/>.
  /// </summary>
  public class FactorySync
  {
    readonly Unchecked.AsyncAide.FactorySync factorySync;

    /// <summary>
    /// Uses <see cref="TaskCreationOptions.None"/>, <see cref="TaskContinuationOptions.None"/> and <see cref="TaskScheduler.Default"/>.
    /// </summary>
    public FactorySync () : this (TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default)
    {
    }

    /// <summary>
    /// .ctor with settings for <see cref="TaskFactory"/>.
    /// </summary>    
    public FactorySync ( TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler )
    {
      if (scheduler is null)
        throw new ArgumentNullException (nameof (scheduler));

      factorySync = new Unchecked.AsyncAide.FactorySync (creationOptions, continuationOptions, scheduler);
    }

    public void RunSync ( Func<Task> func )
    {
      if (func is null)
        throw new ArgumentNullException (nameof (func));

      factorySync.RunSync (func);
    }

    public T RunSync<T> ( Func<Task<T>> func )
    {
      if (func is null)
        throw new ArgumentNullException (nameof (func));

      return factorySync.RunSync (func);
    }
  }
}
