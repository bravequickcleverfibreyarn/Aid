using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Software9119.Aid.Reflection
{
  static public class AssemblyAide
  {
    static public bool IsCollectibleAssembly(Type type)
    {
      Assembly assembly = type.DeclaringType?.Assembly ?? type.Assembly;

      if (!assembly.IsDynamic)
      {
        return false;
      }

      try
      {
        Type assemblyBuilderDataType = Assembly.GetAssembly(typeof(AssemblyBuilder))
            .GetType("System.Reflection.Emit.AssemblyBuilderData");

        object assemblyBuilderData = assembly.GetType()
          .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
          .Single(fi => fi.FieldType == assemblyBuilderDataType)
          .GetValue(assembly);

        object assemblyBuilderAccess = assemblyBuilderDataType
          .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
          .Single(fi => fi.FieldType == typeof(AssemblyBuilderAccess))
          .GetValue(assemblyBuilderData);

        return ((AssemblyBuilderAccess)assemblyBuilderAccess & AssemblyBuilderAccess.RunAndCollect) != 0;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
