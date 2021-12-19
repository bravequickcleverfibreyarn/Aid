using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software9119.Aid.Collection;
using Software9119.Aid.Enumerable;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Collection
{
  [TestClass]
  public class StepTests
  {
    // Arithmetic operators

    [TestMethod]
    public void IncrementOperator ()
    {
      const int homogenicStepSize = 3;
      Step step = new (homogenicStepSize);

      ++step;
      Assert.AreEqual (homogenicStepSize, step);

      step++;
      Assert.AreEqual (homogenicStepSize * 2, step);
    }

    [TestMethod]
    public void DecrementOperator ()
    {
      const int homogenicStepSize = 3;
      Step step = new (homogenicStepSize);

      --step;
      Assert.AreEqual (-homogenicStepSize, step);

      step--;
      Assert.AreEqual (-2 * homogenicStepSize, step);
    }

    [TestMethod]
    public void AddOperator ()
    {
      const int homogenicStepSize = 3;
      Step step = new (homogenicStepSize);

      const int heterogenicStep = 89;

      step += heterogenicStep;
      Assert.AreEqual (heterogenicStep, step);

      step++;
      Assert.AreEqual (heterogenicStep + homogenicStepSize, step);
    }

    [TestMethod]
    public void SubtractOperator ()
    {
      const int homogenicStepSize = 3;
      Step step = new (homogenicStepSize );

      const int heterogenicStep = 89;

      step -= heterogenicStep;
      Assert.AreEqual (-heterogenicStep, step);

      step--;
      Assert.AreEqual (-heterogenicStep - homogenicStepSize, step);
    }

    // Arithmetic operator method-counterparts

    [TestMethod]
    public void IncrementMethod ()
    {
      const int homogenicStepSize = 3;
      Step step = new (homogenicStepSize);

      step.Increment ();
      Assert.AreEqual (homogenicStepSize, step);
    }

    [TestMethod]
    public void DecrementMethod ()
    {
      const int homogenicStepSize = 3;
      Step step = new (homogenicStepSize);

      step.Decrement ();
      Assert.AreEqual (-homogenicStepSize, step);
    }

    [TestMethod]
    public void AddMethod ()
    {
      const int homogenicStepSize = 3;
      Step step = new (homogenicStepSize);

      const int heterogenicStep = 89;

      step.Add (heterogenicStep);
      Assert.AreEqual (heterogenicStep, step);

      step++;
      Assert.AreEqual (heterogenicStep + homogenicStepSize, step);
    }

    [TestMethod]
    public void SubtractMethod ()
    {
      const int homogenicStepSize = 3;
      Step step = new (homogenicStepSize );

      const int heterogenicStep = 89;
      step.Subtract (heterogenicStep);

      Assert.AreEqual (-heterogenicStep, step);

      step--;
      Assert.AreEqual (-heterogenicStep - homogenicStepSize, step);
    }

    // Casting

    [TestMethod]
    public void ImplicitIntCastOperator ()
    {
      Step step = new (3);

      ++step;
      ++step;

      int numStep = step;

      Assert.AreEqual (6, numStep);
    }

    [TestMethod]
    public void FromStepMethod_ToInt32 ()
    {
      Step step = new (3);

      ++step;
      ++step;

      int numStep = step.ToInt32 ();

      Assert.AreEqual (6, numStep);
    }

    // Equality

    [TestMethod]
    public void EqualsObjectMethod ()
    {
      {
        Step step1  = new (3);
        object obj  = new ();

        Assert.IsFalse (step1.Equals ((object) obj));
        Assert.IsFalse (step1.Equals ((object) null));
      }
      {
        Step step1  = new (3);
        object obj  = new Step (3);

        Assert.IsTrue (step1.Equals ((object) obj));

        step1++;
        Assert.IsFalse (step1.Equals ((object) obj));
      }
      {

        Step step1  = new (3);
        object obj  = new Step (4);

        Assert.IsFalse (step1.Equals ((object) obj));
      }
      {
        Step step1 = new (4);
        step1.Increment ();

        Step step2 = new (4);
        step2.Increment ();

        Assert.IsTrue (step1.Equals ((object) step2));
      }
    }

    [TestMethod]
    public void EqualsStepMethod ()
    {
      {
        Step step1  = new (3);
        Step step2  = new (4);

        Assert.IsFalse (step1.Equals ((Step) step2));

        step1++;
        Assert.IsFalse (step1.Equals ((Step) step2));
        step2++;
        Assert.IsFalse (step1.Equals ((Step) step2));
      }
      {
        Step step1  = new (3);
        Step step2  = new (3);

        Assert.IsTrue (step1.Equals ((Step) step2));

        step1++;
        Assert.IsFalse (step1.Equals ((Step) step2));
        step2++;
        Assert.IsTrue (step1.Equals ((Step) step2));
      }
    }

    [TestMethod]
    public void EqualOperator ()
    {
      {
        Step step1  = new (3);
        Step step2  = new (4);

        Assert.IsFalse (step1 == step2);

        step1++;
        Assert.IsFalse (step1 == step2);
        step2++;
        Assert.IsFalse (step1 == step2);
      }
      {
        Step step1  = new (3);
        Step step2  = new (3);

        Assert.IsTrue (step1 == step2);

        step1++;
        Assert.IsFalse (step1 == step2);
        step2++;
        Assert.IsTrue (step1 == step2);
      }
    }

    [TestMethod]
    public void InequalOperator ()
    {
      {
        Step step1  = new (3);
        Step step2  = new (4);

        Assert.IsTrue (step1 != step2);

        step1++;
        Assert.IsTrue (step1 != step2);
        step2++;
        Assert.IsTrue (step1 != step2);
      }
      {
        Step step1  = new (3);
        Step step2  = new (3);

        Assert.IsFalse (step1 != step2);

        step1++;
        Assert.IsTrue (step1 != step2);
        step2++;
        Assert.IsFalse (step1 != step2);
      }
    }

    // Constructors

    [TestMethod]
    public void InitialValueConstructor ()
    {
      const int value = 65536; // 4^8

      Step step = new (4, value);
      Assert.AreEqual (value, step);

      --step;
      Assert.AreEqual (value - 4, step);

      step++;
      step++;
      Assert.AreEqual (value + 4, step);
    }

    [TestMethod]
    public void ZeroSizedStep_ThrowArgumentOutOfRangeException ()
    {
      _ = Assert.ThrowsException<ArgumentOutOfRangeException> (() => new Step (0, default));
      _ = Assert.ThrowsException<ArgumentOutOfRangeException> (() => new Step (0));
    }

    [TestMethod]
    public void DefaultConstructor ()
    {
      const int stepSize = 1;
      Step step = new (stepSize);

      Assert.AreEqual (0, step);
      Assert.AreEqual (stepSize, step.Size);
    }

    // Usage test

    [TestMethod]
    public void Usage ()
    {
      Step step1 = new (3, 0);
      Step step2 = new (3, 1);
      Step step3 = new (3, 2);

      const int size = 90;
      IReadOnlyList<int> source = System.Linq.Enumerable
        .Range(0, size)
        .ToArray(size);

      int[] destination = new int[size];

      int count = source.Count;
      for ( ; step3 < count; )
      {
        destination [step1] = source [step1++];
        destination [step2] = source [step2++];
        destination [step3] = source [step3++];
      }

      Assert.IsTrue (source.SequenceEqual (destination));
    }

    [TestMethod]
    public void Usage2 ()
    {
      const int size = 90;
      IReadOnlyList<int> numbers = System.Linq.Enumerable
        .Range(0, size)
        .ToArray(size);

      Step forward = new (1, 0);
      Step backward = new (1, size -1);

      for ( ; forward < backward; )
        Assert.IsTrue (numbers [forward++] < numbers [backward--]);
    }
  }
}
