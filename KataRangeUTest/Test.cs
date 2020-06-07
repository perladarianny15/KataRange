using System.Collections.Generic;
using KataRange;
using NUnit.Framework;

namespace KataRangeUTest
{
    #region Constructor
    [TestFixture()]
    public class Constructor
    {
        #region Constructor
        [Test()]
        public void First()
        {
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.Constructor.Get("(2,8)", RangePattern));
        }
        [Test()]
        public void Second()
        {
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.Constructor.Get("3,5", RangePattern));
        }
        [Test()]
        public void Third()
        {
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.Constructor.Get("5,9", RangePattern));
        }
        [Test()]
        public void fourth()
        {
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.Constructor.Get("[1,6]", RangePattern));
        }
        #endregion
    }
    #endregion

    #region Contains
    [TestFixture()]
    public class Contains
    {
        #region Contains
        [Test()]
        public void First()
        {
            int[] FirstParameters = { 3, 4, 5, 6 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.Contains.Get("(2,8)", FirstParameters, RangePattern));
        }
        [Test()]
        public void Second()
        {
            int[] SecondParameters = { 2, 7 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.Contains.Get("[3,5]", SecondParameters, RangePattern));
        }
        [Test()]
        public void Third()
        {
            int[] ThirdParameters = { 6, 7, 8, 9 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.Contains.Get("(5,9]", ThirdParameters, RangePattern));
        }
        [Test()]
        public void fourth()
        {
            int[] FouthParameters = { -1, 0, 1, 2, 3 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.Contains.Get("[1,6]", FouthParameters, RangePattern));
        }
        #endregion
    }
    #endregion

    #region DoesntContains
    [TestFixture()]
    public class DoesntContains
    {
        #region Contains
        [Test()]
        public void First()
        {
            int[] FirstParameters = { -2, -1, 0, 1 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.DoesntContains.Get("(2,8)", FirstParameters, RangePattern));
        }
        [Test()]
        public void Second()
        {
            int[] SecondParameters = { 4, 5 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.DoesntContains.Get("[3,5]", SecondParameters, RangePattern));
        }
        [Test()]
        public void Third()
        {
            int[] ThirdParameters = { -1, -2, -3, 2, 3, 4 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.DoesntContains.Get("(5,9]", ThirdParameters, RangePattern));
        }
        [Test()]
        public void fourth()
        {
            int[] FouthParameters = { 1, 3, 4 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.DoesntContains.Get("[1,6]", FouthParameters, RangePattern));
        }
        #endregion
    }
    #endregion

    #region ContainsRange
    [TestFixture()]
    public class ContainsRange
    {
        #region Contains
        [Test()]
        public void First()
        {
            int[] FirstParameters = { 1, 10 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.ContainsRange.Get("(2,8)", FirstParameters, RangePattern));
        }
        [Test()]
        public void Second()
        {
            int[] SecondParameters = { 2, 6 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.ContainsRange.Get("[3,5]", SecondParameters, RangePattern));
        }
        [Test()]
        public void Third()
        {
            int[] ThirdParameters = { 6, 8 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.ContainsRange.Get("(5,9]", ThirdParameters, RangePattern));
        }
        [Test()]
        public void fourth()
        {
            int[] FouthParameters = { 1, 5 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.ContainsRange.Get("[1,6)", FouthParameters, RangePattern));
        }
        #endregion
    }
    #endregion

    #region DoesntContainsRange
    [TestFixture()]
    public class DoesntContainsRange
    {
        #region Contains
        [Test()]
        public void First()
        {
            int[] FirstParameters = { 1, 9 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.DoesntContainsRange.Get("(2,8)", FirstParameters, RangePattern));
        }
        [Test()]
        public void Second()
        {
            int[] SecondParameters = { 1, 6 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.DoesntContainsRange.Get("[3,5]", SecondParameters, RangePattern));
        }
        [Test()]
        public void Third()
        {
            int[] ThirdParameters = { 6, 8 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.DoesntContainsRange.Get("(5,9]", ThirdParameters, RangePattern));
        }
        [Test()]
        public void fourth()
        {
            int[] FouthParameters = { 1, 5 };
            string RangePattern = @"-?[0-9]";
            Assert.IsTrue(KataRange.DoesntContainsRange.Get("[1,6]", FouthParameters, RangePattern));
        }
        #endregion
    }
    #endregion

    #region EndPoints
    [TestFixture()]
    public class EndPoint
    {
        #region EndPoint
        [Test()]
        public void First()
        {
            List<int> VerifyParameters = new List<int> { 3, 7 };
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreEqual(VerifyParameters, EndPoints.Get("(2,8)", RangePattern));

        }
        [Test()]
        public void Second()
        {
            List<int> VerifyParameters = new List<int> { 3, 5 };
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreEqual(VerifyParameters, EndPoints.Get("[3,5]", RangePattern));
        }
        [Test()]
        public void Third()
        {
            List<int> VerifyParameters = new List<int> { -1, 0 };
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreEqual(VerifyParameters, EndPoints.Get("(5,9]", RangePattern));
        }
        [Test()]
        public void fourth()
        {
            List<int> VerifyParameters = new List<int> { 6, 7 };
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreEqual(VerifyParameters, EndPoints.Get("[1,6]", RangePattern));
        }
        #endregion
    }
    #endregion

    #region AllPoints
    [TestFixture()]
    public class AllPoints
    {
        #region AllPoints
        [Test()]
        public void First()
        {
            List<int> VerifyParameters = new List<int> { 3, 4, 5, 6, 7 };
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreEqual(VerifyParameters, KataRange.AllPoints.Get("(2,8)", RangePattern));

        }
        [Test()]
        public void Second()
        {
            List<int> VerifyParameters = new List<int> { 3, 5, 10 };
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreEqual(VerifyParameters, KataRange.AllPoints.Get("[3,5]", RangePattern));
        }
        [Test()]
        public void Third()
        {
            List<int> VerifyParameters = new List<int> { -1, 0, 1 };
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreEqual(VerifyParameters, KataRange.AllPoints.Get("(5,9]", RangePattern));
        }
        [Test()]
        public void fourth()
        {
            List<int> VerifyParameters = new List<int> { 1, 2, 3, 4, 5 };
            string RangePattern = @"-?[0-9]";
            CollectionAssert.AreEqual(VerifyParameters, KataRange.AllPoints.Get("[1,6)", RangePattern));
        }
        #endregion
    }
    #endregion

    #region IsEqual
    [TestFixture()]
    public class IsEqual
    {
        #region IsNotEqual
        [Test()]
        public void First()
        {
            Assert.IsTrue(KataRange.IsEqual.Get("(2,8)", "{3,10)"));
        }
        [Test()]
        public void Second()
        {
            Assert.IsTrue(KataRange.IsEqual.Get("[3,5]", "[3,5]"));
        }
        [Test()]
        public void Third()
        {
            Assert.IsTrue(KataRange.IsEqual.Get("(5,9]", "{11,15)"));
        }
        [Test()]
        public void fourth()
        {
            Assert.IsTrue(KataRange.IsEqual.Get("[1,6)", "[1,6)"));
        }
        #endregion
    }
    #endregion

    #region IsNotEqual
    [TestFixture()]
    public class IsNotEqual
    {
        #region IsNotEqual
        [Test()]
        public void First()
        {
            Assert.IsTrue(KataRange.IsNotEqual.Get("(2,8)", "(1,9)"));
        }
        [Test()]
        public void Second()
        {
            Assert.IsTrue(KataRange.IsNotEqual.Get("[3,5]", "{6,8}"));
        }
        [Test()]
        public void Third()
        {
            Assert.IsTrue(KataRange.IsNotEqual.Get("(5,9]", "(5,9]"));
        }
        [Test()]
        public void fourth()
        {
            Assert.IsTrue(KataRange.IsNotEqual.Get("[1,6)", "[1,6)"));
        }
        #endregion
    }
    #endregion

    #region OverLaps
    [TestFixture()]
    public class OverLaps
    {
        [Test()]
        public void First()
        {
            Overlaps.Interval[] arr1 = { new Overlaps.Interval(2,5),
                        new Overlaps.Interval(7, 10)};
            int n1 = arr1.Length;

            Assert.IsTrue(Overlaps.isOverlap(arr1, n1));
        }
        [Test()]
        public void Second()
        {
            Overlaps.Interval[] arr1 = { new Overlaps.Interval(2,5),
                        new Overlaps.Interval(3, 10)};
            int n1 = arr1.Length;

            Assert.IsTrue(Overlaps.isOverlap(arr1, n1));
        }
        [Test()]
        public void Third()
        {
            Overlaps.Interval[] arr1 = { new Overlaps.Interval(-1,2),
                        new Overlaps.Interval(7, 10)};
            int n1 = arr1.Length;

            Assert.IsTrue(Overlaps.isOverlap(arr1, n1));
        }
        [Test()]
        public void Fourth()
        {
            Overlaps.Interval[] arr1 = { new Overlaps.Interval(3,5),
                        new Overlaps.Interval(2, 10)};
            int n1 = arr1.Length;

            Assert.IsTrue(Overlaps.isOverlap(arr1, n1));
        }
    }
    #endregion

    #region DoesntOverlaps

    [TestFixture()]
    public class DoesntOverlaps
    {
        [Test()]
        public void First()
        {
            Overlaps.Interval[] arr1 = { new Overlaps.Interval(2,5),
                        new Overlaps.Interval(7, 10)};
            int n1 = arr1.Length;

            Assert.IsFalse(Overlaps.isOverlap(arr1, n1));
        }
        [Test()]
        public void Second()
        {
            Overlaps.Interval[] arr1 = { new Overlaps.Interval(2,5),
                        new Overlaps.Interval(3, 10)};
            int n1 = arr1.Length;

            Assert.IsFalse(!Overlaps.isOverlap(arr1, n1));
        }
        [Test()]
        public void Third()
        {
            Overlaps.Interval[] arr1 = { new Overlaps.Interval(-1,2),
                        new Overlaps.Interval(7, 10)};
            int n1 = arr1.Length;

            Assert.IsFalse(Overlaps.isOverlap(arr1, n1));
        }
        [Test()]
        public void Fourth()
        {
            Overlaps.Interval[] arr1 = { new Overlaps.Interval(3,5),
                        new Overlaps.Interval(2, 10)};
            int n1 = arr1.Length;

            Assert.IsFalse(Overlaps.isOverlap(arr1, n1));
        }
    }
    #endregion
}
