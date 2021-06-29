
using System.Threading;
using System.Threading.Tasks;

namespace Software9119.Aid.Concurrency
{
  static public class WaitHandleExtensions
  {
    /// <summary>
    /// Provides <see cref="WaitHandle"/> with task-pattern base asynchronicity.
    /// </summary>    
    public static Task<bool> WaitOneAsync(this WaitHandle waitHandle, int? timeoutMilisecs = null)
    {
      if (timeoutMilisecs is null)
      {
        timeoutMilisecs = -1; // Infinite.
      }

      var tcs = new TaskCompletionSource<bool>();

      RegisteredWaitHandle rwh = ThreadPool.RegisterWaitForSingleObject
      (
          waitHandle,
          (_, timedOut) => tcs.SetResult(!timedOut),
          null,
          timeoutMilisecs.Value,
          true);

      tcs.Task.ContinueWith(_ => rwh.Unregister(null), TaskScheduler.Default);
      return tcs.Task;
    }
  }

}
