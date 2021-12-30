using System;
using System.Threading;
using System.Threading.Tasks;

namespace Software9119.Aid.Concurrency;

static public partial class WaitHandleExtensions
{
  /// <remarks>
  /// Use <see cref="Timeout.InfiniteTimeSpan"/> for no timeout and <see cref="TimeSpan.Zero"/> for immediate timeout.
  /// </remarks>
  /// <exception cref="ArgumentNullException">When any reference is <see langword="null"/>.</exception>
  /// <exception cref="TaskCanceledException" />
  static public Task<bool> WaitOneAsync ( this WaitHandle wh, CancellationToken ct, TimeSpan maxWaitTime, TaskScheduler scheduler )
  {
    Validate (wh, scheduler);
    return Unchecked.WaitHandleExtensions.WaitOneAsync (wh, ct, maxWaitTime, scheduler);
  }

  /// <remarks>
  /// Use <c>0</c> for no timeout and <c>-1</c> for immediate timeout.
  /// </remarks>
  /// <exception cref="ArgumentNullException">When any reference is <see langword="null"/>.</exception>
  /// <exception cref="TaskCanceledException" />
  static public Task<bool> WaitOneAsync ( this WaitHandle wh, CancellationToken ct, int maxWaitTime, TaskScheduler scheduler )
  {
    Validate (wh, scheduler);
    return Unchecked.WaitHandleExtensions.WaitOneAsync (wh, ct, maxWaitTime, scheduler);
  }

  static void Validate ( WaitHandle wh, TaskScheduler scheduler )
  {
    if (wh is null)
      throw new ArgumentNullException (nameof (wh));

    if (scheduler is null)
      throw new ArgumentNullException (nameof (scheduler));
  }
}
