using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Concurrency;

using System;
using System.Threading.Tasks;

namespace Test.Concurrency;

[TestClass]
public class AsyncAidTests_FactorySync
{

  [TestMethod]
  public void AsyncAideFactorySyncCtor__NullTaskScheduler___ThrowsArgumentNullException ()
  {
    _ = Assert.ThrowsException<ArgumentNullException> (() => new AsyncAide.FactorySync (default, default, null));
  }

  // RunSync

  [TestMethod]
  public void RunSync__ExecuteVoidTask___NoDeadLock ()
  {
    object obj = null;

    AsyncAide.FactorySync factorySync = new ();

    factorySync.RunSync (Test);
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
    AsyncAide.FactorySync factorySync = new ();

    _ = Assert.ThrowsException<ArgumentNullException> (() => factorySync.RunSync (null));
  }

  // RunSyncT

  [TestMethod]
  public void RunSyncT__ExecuteTTask___NoDeadLock ()
  {
    const int test = 33;

    AsyncAide.FactorySync factorySync = new ();

    Assert.AreEqual (test, factorySync.RunSync (Test));

    static async Task<int> Test ()
    {
      await Task.Delay (1);
      return test;
    }
  }

  [TestMethod]
  public void RunSyncT__NullFunction___ThrowsArgumentNullExcpetion ()
  {
    AsyncAide.FactorySync factorySync = new ();

    _ = Assert.ThrowsException<ArgumentNullException> (() => factorySync.RunSync<int> (null));
  }
}
