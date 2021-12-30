using System;
using System.Threading;
using System.Threading.Tasks;

namespace Software9119.Aid.Concurrency.Unchecked;

/// <summary>
/// Provides core functionality for <see cref="Concurrency.WaitHandleExtensions"/> 
/// without parameter checks.
/// </summary>
static public class WaitHandleExtensions
{

  /// <remarks>
  /// Use <see cref="Timeout.InfiniteTimeSpan"/> for no timeout and <see cref="TimeSpan.Zero"/> for immediate timeout.
  /// </remarks>
  /// <exception cref="ArgumentNullException">When any reference is <see langword="null"/>.</exception>
  /// <exception cref="TaskCanceledException" />
  static public Task<bool> WaitOneAsync ( this WaitHandle wh, CancellationToken ct, TimeSpan maxWaitTime, TaskScheduler scheduler )
  {
    return wh.WaitOneAsync (ct, (int) maxWaitTime.TotalMilliseconds, scheduler);
  }

  /// <remarks>
  /// Use <c>0</c> for no timeout and <c>-1</c> for immediate timeout.
  /// </remarks>
  /// <exception cref="ArgumentNullException">When any reference is <see langword="null"/>.</exception>
  /// <exception cref="TaskCanceledException" />
  static public Task<bool> WaitOneAsync ( this WaitHandle wh, CancellationToken ct, int maxWaitTime, TaskScheduler scheduler )
  {
    TaskCompletionSource<bool> tcs      = new ();
    CancellationTokenRegistration ctr   = default;

    if (ct != CancellationToken.None)
      ctr = ct.Register (() => tcs.TrySetCanceled (ct));

    RegisteredWaitHandle rwh = ThreadPool.RegisterWaitForSingleObject
      (
        wh,
        (_, timedOut) => tcs.TrySetResult(!timedOut),
        null,
        maxWaitTime,
        true
      );

    Task<bool> acquisition = tcs.Task;

    _ = acquisition.ContinueWith
    (
      async __ =>
      {
        if (ctr != default)
          await ctr.DisposeAsync ().ConfigureAwait (false);

        _ = rwh.Unregister (null);
      },
      scheduler
    );

    return acquisition;
  }
}

