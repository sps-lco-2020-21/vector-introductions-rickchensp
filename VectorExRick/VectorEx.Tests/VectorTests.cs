using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VectorEx.Lib;

namespace VectorEx.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void TestAdd()
        {
            Vector A = new Vector(3, new List<double> { 4, 8, 12 });
            Vector B = new Vector(3, new List<double> { 14, 16, 19 });
            Assert.AreEqual("18, 24, 31", A.Add(B).ToString());
        }

        [TestMethod]
        public void TestScalerMultiply()
        {
            Vector A = new Vector(4, new List<double> { 1, 3, 5, 9 });
            Assert.AreEqual("3, 9, 15, 27", A.ScalarMultiply(3).ToString());
        }

        [TestMethod]
        public void TestDot()
        {
            Vector A = new Vector(3, new List<double> { 3, 5, -1 });
            Vector B = new Vector(3, new List<double> { 2, 6, 7 });
            Assert.AreEqual(29, A.Dot(B));
        }

        [TestMethod]
        public void TestConvexCombination()
        {
            Vector A = new Vector(2, new List<double> { 4, 8 });
            Vector B = new Vector(2, new List<double> { 14, 16 });
            Assert.AreEqual("12, 14.4", A.ConvexCombination(0.2, B).ToString());
        }

        [TestMethod]
        public void TestAngleBetween()
        {
            Vector A = new Vector(2, new List<double> { 1, 1 });
            Vector B = new Vector(2, new List<double> { 1, 0 });
            Assert.AreEqual(Math.Round(Math.PI / 4, 10), Math.Round(A.AngleBetween(B),10));
        }
    }
}
