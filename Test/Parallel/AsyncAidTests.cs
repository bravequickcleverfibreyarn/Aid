using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software9119.Aid.Parallel;
using System.Threading.Tasks;

namespace Test.Parallel
{
  [TestClass]
  public class AsyncAidTests
  {

    string testStr = "a";
    [TestMethod]
    public void RunSync_ExecuteVoidTask_MethodExecuted()
    {      
      new AsyncAid().RunSync(ExtendStringWithB);
      Assert.AreEqual("ab", testStr);
    }

    [TestMethod]
    public void RunSyncT_ExecuteTTask_MethodExecuted()
    { 
      Assert.AreEqual("ab", new AsyncAid().RunSync(() => StringExtendedWithB("a")));
    }

    async Task ExtendStringWithB() => await Task.Run(() => testStr += 'b');
    async Task<string> StringExtendedWithB(string str) => await Task.Run(() => str + 'b');
  }
}