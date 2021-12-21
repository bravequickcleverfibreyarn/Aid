using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Concurrency;

using System.Threading.Tasks;

namespace Test.Concurrency;

[TestClass]
public class AsyncAidTests
{

  string testStr = "a";
  [TestMethod]
  public void RunSync_ExecuteVoidTask_MethodExecuted ()
  {
    new AsyncAide ().RunSync (ExtendStringWithB);
    Assert.AreEqual ("ab", testStr);
  }

  [TestMethod]
  public void RunSyncT_ExecuteTTask_MethodExecuted ()
  {
    Assert.AreEqual ("ab", new AsyncAide ().RunSync (() => StringExtendedWithB ("a")));
  }

  async Task ExtendStringWithB () => await Task.Run (() => testStr += 'b');
  static async Task<string> StringExtendedWithB ( string str ) => await Task.Run (() => str + 'b');
}
