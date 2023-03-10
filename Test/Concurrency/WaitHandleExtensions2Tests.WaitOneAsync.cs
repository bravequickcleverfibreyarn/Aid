
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Concurrency;

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Concurrency;

[TestClass]
sealed public class WaitHandleExtensionsTests_WaitOneAsync
{
  [TestMethod]
  public void CancellationRequested__TaskIsCancelled ()
  {

    using EventWaitHandle ewh = new (false, EventResetMode.AutoReset);

    using CancellationTokenSource cts = new ();
    // Set up cancellable call.
    Task<bool> test = ewh.WaitOneAsync (cts.Token, Timeout.InfiniteTimeSpan, TaskScheduler.Current);

    cts.Cancel ();

    AggregateException aggregateException = Assert.ThrowsException<AggregateException> (() => test.Wait ());

    ReadOnlyCollection<System.Exception> innerExceptions = aggregateException.InnerExceptions;
    Assert.AreEqual (1, innerExceptions.Count);
    Assert.AreEqual (typeof (TaskCanceledException), innerExceptions [0]!.GetType ());
  }

  [TestMethod]
  async public Task WaitHandleBlocks__CannotTakeWaithHandle ()
  {
    using EventWaitHandle ewh = new (false, EventResetMode.AutoReset);

    Assert.IsFalse
    (
      await ewh.WaitOneAsync (CancellationToken.None, TimeSpan.Zero, TaskScheduler.Current)
    );
  }

  [TestMethod]
  async public Task TakeWaithHandle_WaitHandleTaken ()
  {

    using EventWaitHandle ewh = new (true, EventResetMode.AutoReset);

    Assert.IsTrue
    (
      await ewh.WaitOneAsync (CancellationToken.None, Timeout.InfiniteTimeSpan, TaskScheduler.Current)
    );

    Assert.IsFalse (ewh.WaitOne (0));
  }

  [TestMethod]
  async public Task WaitWithTimeout_TimeoutExpires ()
  {

    using EventWaitHandle ewh = new (false, EventResetMode.AutoReset);

    const uint timeoutSeconds = 1;
    var sw = Stopwatch.StartNew();

    bool taken = await ewh.WaitOneAsync
    (
      CancellationToken.None,
      TimeSpan.FromSeconds(timeoutSeconds),
      TaskScheduler.Current
    );

    sw.Stop ();

    Assert.IsTrue (timeoutSeconds < sw.Elapsed.TotalSeconds);
    Assert.IsTrue (sw.Elapsed.TotalSeconds - timeoutSeconds < 1);
    Assert.IsFalse (taken);
  }

  [TestMethod]
  public void PassNullTaskScheduler__ThrowsArgumentNullException ()
  {
    using EventWaitHandle ewh = new (default(bool), default(EventResetMode));

    _ = Assert.ThrowsException<ArgumentNullException>
    (
      () => ewh.WaitOneAsync (default (CancellationToken), default (TimeSpan), scheduler: null!).Wait ()
    );

    _ = Assert.ThrowsException<ArgumentNullException>
    (
      () => ewh.WaitOneAsync (default (CancellationToken), default (int), scheduler: null!).Wait ()
    );
  }

  [TestMethod]
  public void PassNullEventWaitHandle__ThrowsArgumentNullException ()
  {
    using EventWaitHandle ewh  = null;
    TaskScheduler scheduler     = TaskScheduler.Default;

    _ = Assert.ThrowsException<ArgumentNullException>
    (
      () => ewh!.WaitOneAsync (default (CancellationToken), default (TimeSpan), scheduler).Wait ()
    );

    _ = Assert.ThrowsException<ArgumentNullException>
    (
      () => ewh!.WaitOneAsync (default (CancellationToken), default (int), scheduler).Wait ()
    );
  }
}