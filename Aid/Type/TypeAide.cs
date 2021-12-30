using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

using sType = System.Type;

namespace Software9119.Aid.Type;

static public class TypeAide
{
  static readonly ConcurrentDictionary<sType, bool> cache = new();

  static public bool IsUnManaged ( sType type )
  {
    if (type == null)
    {
      throw new ArgumentNullException (nameof (type));
    }

    if (cache.ContainsKey (type))
    {
      return cache [type];
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
        .GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
        .All (fi => IsUnManaged (fi.FieldType));
    }

    _ = cache.TryAdd (type, unmanaged);
    return unmanaged;
  }
}
