using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software9119.Aid.Reflection;
using System;
using System.Reflection;
using System.Reflection.Emit;
using Access = System.Reflection.Emit.AssemblyBuilderAccess;


namespace TestFramework
{
  [TestClass]
  public class AssemblyAideTests
  {
    [TestMethod]
    public void IsCollectibleAssembly_ItIsNotDynamic_FalseReturned()
    {
      Assert.IsFalse(AssemblyAide.IsCollectibleAssembly(typeof(string)));
    }

    [TestMethod]
    [DataRow(Access.Run, false)]
    [DataRow(Access.Save, false)]
    [DataRow(Access.RunAndSave, false)]
    [DataRow(Access.ReflectionOnly, false)]    
    [DataRow(Access.RunAndCollect, true)]    
    public void IsCollectibleAssembly_DynamicAssembly_ExpectedResultReturned(Access aba, bool result)
    {      
      AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("TestAssemblyName"), aba);
      ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("TestModuleName");
      TypeBuilder typeBuilder = moduleBuilder.DefineType("TestType", TypeAttributes.Public);

      Type type = typeBuilder.CreateType();

      Assert.AreEqual(result, AssemblyAide.IsCollectibleAssembly(type));
    }
  }
}
