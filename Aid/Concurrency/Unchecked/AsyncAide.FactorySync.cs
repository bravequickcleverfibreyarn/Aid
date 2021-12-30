
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Software9119.Aid.Concurrency.Unchecked;

static public partial class AsyncAide
{
  /// <summary>
  /// core functionality for <see cref="Concurrency.AsyncAide.FactorySync"/>
  /// </summary>
  public class FactorySync
  {
    readonly TaskFactory factory;

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
      factory = new TaskFactory (CancellationToken.None, creationOptions, continuationOptions, scheduler);
    }

    [SuppressMessage ("Reliability", "CA2008:Do not create tasks without passing a TaskScheduler", Justification = "")]
    public void RunSync ( Func<Task> func )
    {
      factory
        .StartNew (func)
        .Unwrap ()
        .GetAwaiter ()
        .GetResult ();
    }

    [SuppressMessage ("Reliability", "CA2008:Do not create tasks without passing a TaskScheduler", Justification = "")]
    public T RunSync<T> ( Func<Task<T>> func )
    {
      return factory
        .StartNew (func)
        .Unwrap ()
        .GetAwaiter ()
        .GetResult ();
    }
  }
}
