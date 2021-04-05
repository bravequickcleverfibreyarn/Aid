
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Software9119.Aid.Concurrency
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
  public class AsyncAide
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
  {
    readonly TaskFactory factory;

    /// <summary>
    /// Will use <see cref="TaskCreationOptions.None"/>, <see cref="TaskContinuationOptions.None"/> and <see cref="TaskScheduler.Default"/>.
    /// </summary>
    public AsyncAide() : this(TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default)
    {
    }

    /// <summary>
    /// .ctor with settings for <see cref="TaskFactory"/>.
    /// </summary>    
    public AsyncAide(TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler)
    {
      factory = new TaskFactory(CancellationToken.None, creationOptions, continuationOptions, scheduler);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [SuppressMessage("Reliability", "CA2008:Do not create tasks without passing a TaskScheduler", Justification = "")]
    public void RunSync(Func<Task> func)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
      factory
        .StartNew(func)
        .Unwrap()
        .GetAwaiter()
        .GetResult();
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [SuppressMessage("Reliability", "CA2008:Do not create tasks without passing a TaskScheduler", Justification = "")]
    public T RunSync<T>(Func<Task<T>> func)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
      return factory
        .StartNew(func)
        .Unwrap()
        .GetAwaiter()
        .GetResult();
    }
  }
}