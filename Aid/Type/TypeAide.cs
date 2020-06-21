using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

using sType = System.Type;

namespace Software9119.Aid.Type
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
  public class TypeAide
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
  {
    static readonly ConcurrentDictionary<sType, bool> cache = new ConcurrentDictionary<sType, bool>();

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    static public bool IsUnManaged(sType type)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {      
      if (cache.ContainsKey(type))
      {
        return cache[type];
      }

      bool unmanaged = false;
      if (type.IsPrimitive || type.IsPointer || type.IsEnum)
      {
        unmanaged = true;
      }
      else if (!type.IsValueType)
      {
        unmanaged = false;
      }      
      else
      {
        unmanaged = type
          .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
          .All(fi => IsUnManaged(fi.FieldType));
      }

      cache.TryAdd(type, unmanaged);
      return unmanaged;
    }
  }
}