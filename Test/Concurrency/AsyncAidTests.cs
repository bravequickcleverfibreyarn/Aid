using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Concurrency;

using System;
using System.Threading.Tasks;

namespace Test.Concurrency;

[TestClass]
public class AsyncAidTests
{
  // RunSync

  [TestMethod]
  public void RunSync__ExecuteVoidTask___NoDeadLock ()
  {
    object obj = null;

    AsyncAide.RunSync (Test);
    Assert.AreNotEqual (null, obj);

    async Task Test ()
    {
      await Task.Delay (1);
      obj = new object ();
    }
  }

  [TestMethod]
  public void RunSync__NullFunction___ThrowsArgumentNullExcpetion ()
  {
    _ = Assert.ThrowsException<ArgumentNullException> (() => AsyncAide.RunSync (null));
  }

  // RunSyncT

  [TestMethod]
  public void RunSyncT__ExecuteTTask___NoDeadLock ()
  {
    const int test = 33;

    Assert.AreEqual (test, AsyncAide.RunSync (Test));

    static async Task<int> Test ()
    {
      await Task.Delay (1);
      return test;
    }
  }

  [TestMethod]
  public void RunSyncT__NullFunction___ThrowsArgumentNullExcpetion ()
  {
    _ = Assert.ThrowsException<ArgumentNullException> (() => AsyncAide.RunSync<int> (null));
  }
}
