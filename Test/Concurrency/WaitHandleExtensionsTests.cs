using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Concurrency;

using System.Threading;
using System.Threading.Tasks;

namespace Test.Concurrency
{
  [TestClass]
  public class WaitHandleExtensionsTests
  {
    [TestMethod]
    public void WaitOneAsync_NormalUsageEventNotSet_AsyncBehavior()
    {
      WaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

      Task<bool> task = eventWaitHandle.WaitOneAsync();
      Thread.Sleep(400);

      Assert.AreEqual(TaskStatus.WaitingForActivation, task.Status);

      _ = ((EventWaitHandle)eventWaitHandle).Set();
      Thread.Sleep(400);

      Assert.AreEqual(TaskStatus.RanToCompletion, task.Status);
      Assert.AreEqual(true, task.Result);

      eventWaitHandle.Dispose();
    }

    [TestMethod]
    public void WaitOneAsync_NormalUsageEventSet_AsyncBehaviorNoWait()
    {
      WaitHandle eventWaitHandle = new EventWaitHandle(true, EventResetMode.AutoReset);

      Task<bool> task = eventWaitHandle.WaitOneAsync();
      Thread.Sleep(400);

      Assert.AreEqual(TaskStatus.RanToCompletion, task.Status);
      Assert.AreEqual(true, task.Result);

      eventWaitHandle.Dispose();
    }

    [TestMethod]
    public void WaitOneAsync_TimeoutSetEventNotSet_TimedOut()
    {
      WaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

      Task<bool> task = eventWaitHandle.WaitOneAsync(1_000);
      Thread.Sleep(400);

      Assert.AreEqual(TaskStatus.WaitingForActivation, task.Status);

      _ = task.ContinueWith
      (
        x =>
        {
          Assert.AreEqual(TaskStatus.RanToCompletion, x.Status);
          Assert.AreEqual(false, task.Result);
        }
      );

      eventWaitHandle.Dispose();
    }

    [TestMethod]
    public void WaitOneAsync_TimeoutSetEventSet_AsyncBehaviorNoWait()
    {
      WaitHandle eventWaitHandle = new EventWaitHandle(true, EventResetMode.AutoReset);

      Task<bool> task = eventWaitHandle.WaitOneAsync(1_000);
      Thread.Sleep(100);

      Assert.AreEqual(TaskStatus.RanToCompletion, task.Status);
      Assert.AreEqual(true, task.Result);

      eventWaitHandle.Dispose();
    }

  }
}
