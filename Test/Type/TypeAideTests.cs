using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software9119.Aid.Type;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Test.Type;

[TestClass]
[SuppressMessage ("Performance", "CA1823:Avoid unused private fields", Justification = "")]
public class TypeAideTests
{
  [DataRow (typeof (sbyte), true)]
  [DataRow (typeof (byte), true)]
  [DataRow (typeof (short), true)]
  [DataRow (typeof (ushort), true)]
  [DataRow (typeof (int), true)]
  [DataRow (typeof (uint), true)]
  [DataRow (typeof (long), true)]
  [DataRow (typeof (ulong), true)]
  [DataRow (typeof (char), true)]
  [DataRow (typeof (float), true)]
  [DataRow (typeof (double), true)]
  [DataRow (typeof (decimal), true)]
  [DataRow (typeof (bool), true)]
  [DataRow (typeof (Enum), true)]
  [DataRow (typeof (UnManaged), true)]
  [DataRow (typeof (Constructed1<int>), true)]
  [DataRow (typeof (Constructed1<object>), true)]
  [DataRow (typeof (Constructed2<int>), true)]
  [DataRow (typeof (Constructed2<object>), false)]
  [DataRow (typeof (Managed), false)]
  [DataRow (typeof (string), false)]
  [DataRow (typeof (sbyte*), true)]
  [DataRow (typeof (byte*), true)]
  [DataRow (typeof (short*), true)]
  [DataRow (typeof (ushort*), true)]
  [DataRow (typeof (int*), true)]
  [DataRow (typeof (uint*), true)]
  [DataRow (typeof (long*), true)]
  [DataRow (typeof (ulong*), true)]
  [DataRow (typeof (char*), true)]
  [DataRow (typeof (float*), true)]
  [DataRow (typeof (double*), true)]
  [DataRow (typeof (decimal*), true)]
  [DataRow (typeof (bool*), true)]
  [DataRow (typeof (Enum*), true)]
  [DataRow (typeof (UnManaged*), true)]
  [DataRow (typeof (Constructed1<int>*), true)]
  [DataRow (typeof (Constructed1<object>*), true)]
  [DataRow (typeof (Constructed2<int>*), true)]
  [TestMethod]
  public void IsUnManaged_ProvidedValue_ComplyExpectation ( System.Type type, bool expectation )
  {
#pragma warning disable CS0618 // Type or member is obsolete
    Assert.AreEqual (expectation, TypeAide.IsUnManaged (type));
#pragma warning restore CS0618 // Type or member is obsolete
  }

  struct Constructed1<T>
  {
  }

#pragma warning disable CS0169

  struct Constructed2<T>
  {
    T t;
  }

  struct Managed
  {
    string str;
  }

  struct UnManaged
  {
    int i;
  }
#pragma warning restore CS0169
  enum Enum
  {
  }

  [TestMethod]
  public void IsUnManaged_CacheTest_CashIsUsed ()
  {
    var cache = (ConcurrentDictionary<System.Type, bool>)typeof(TypeAide)
        .GetField("cache", BindingFlags.NonPublic | BindingFlags.Static)
        .GetValue(null);

    Assert.IsTrue (cache.IsEmpty);

    System.Type typeOfInt = typeof(int);

#pragma warning disable CS0618 // Type or member is obsolete
    Assert.IsTrue (TypeAide.IsUnManaged (typeOfInt));
#pragma warning restore CS0618 // Type or member is obsolete

    Assert.IsTrue (cache.ContainsKey (typeOfInt));

    cache [typeOfInt] = false;

#pragma warning disable CS0618 // Type or member is obsolete
    Assert.IsFalse (TypeAide.IsUnManaged (typeOfInt));
#pragma warning restore CS0618 // Type or member is obsolete

    cache.Clear ();
  }

  [TestMethod]
  public void IsUnManaged_NullType_ThrowsArgumentNullException ()
  {
    _ = Assert.ThrowsException<ArgumentNullException>
    (
#pragma warning disable CS0618 // Type or member is obsolete
      () => TypeAide.IsUnManaged (null)
#pragma warning restore CS0618 // Type or member is obsolete
    );
  }
}
