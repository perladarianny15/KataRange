using System;
using NUnit.Framework;

namespace KataRangeUTest
{
    #region Constructor
    [TestFixture()]

    public class Constructor{

        [Test()]
        public void RangeIsCorrect()
        {
            string RangePattern = @"-?[0-9]";
            Assert.IsFalse(KataRange.Constructor.Get("3,5", RangePattern));
        }
    }
    #endregion

    #region Contains
    [TestFixture()]

    public class Contains
    {
        [Test()]
        public void RangeIsNull()
        {
            int[] Parameters = new int[] { 3, 4, 5, 6 };

            string RangePattern = @"-?[0-9]";
            Assert.IsNull(KataRange.Contains.Get("(2,8)", null, RangePattern));

        }
    }
    #endregion

    #region DoesntContains
    [TestFixture()]
    public class DoesNotContains
    {
        [Test()]
        public void IsCorrectParameters()
        {
            int[] Parameters = new int[] {4,5};
            string RangePattern = @"-?[0-9]";
            Assert.IsFalse(KataRange.DoesntContains.Get("[3,5]", Parameters, RangePattern));

        }
    }
    #endregion

    #region Allpoints

    [TestFixture()]

    public class AllPoints
    {
        [Test()]
        public void TestPoints()
        {
            int[] Parameters = new int[] {3,4,5};
            string RangePattern = @"-?[0-9]";

            CollectionAssert.AreEquivalent(Parameters, KataRange.AllPoints.Get("[3,5]", RangePattern));
        }
    }
    #endregion

    #region Endpoints

    [TestFixture()]

    public class Endpoints
    {
        [Test()]
        public void IsEndPoint()
        {
            int[] Parameters = new int[] {-3,-4,-5};
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreNotEquivalent(Parameters, KataRange.EndPoints.Get("(2,8)", RangePattern));
        }
    }

    #endregion

    #region IsEqual
    [TestFixture()]
    public class IsEqual
    {
        [Test()]
        public void TestEqual()
        {
            Assert.IsTrue(KataRange.IsEqual.Get("(3,7)", "(3,7)"));
        }
    }
    #endregion

    #region IsNotEqual
    [TestFixture()]
    public class IsNotEqual
    {
        [Test()]
        public void TestIsEmptyRange()
        {
            Assert.IsEmpty(KataRange.IsNotEqual.Get(string.Empty, "(3,7)"));
        }
    }
    #endregion
}
