using Microsoft.VisualStudio.TestTools.UnitTesting;
using DreamCareer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamCareer.Tests
{
    [TestClass()]
    public class VectorTests
    {
        [TestMethod()]
        public void VectorTest()
        {
            Vector v = new Vector(new double[] { 1, 2, 1 });
            Assert.AreEqual(v.Rows, 3);
            Assert.AreEqual(v.GetValue(0), 1);
            Assert.AreEqual(v.GetValue(1), 2);
            Assert.AreEqual(v.GetValue(2), 1);
            try
            {
                v.GetValue(3);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                ;
            }

        }

        [TestMethod()]
        public void VectorTest1()
        {
            Vector v = new Vector(4);
            Assert.AreEqual(v.Rows, 4);
        }

        [TestMethod()]
        public void GetValueTest()
        {
            Vector v = new Vector(new double[] { 1, 2, 3, 4 });
            Assert.AreEqual(v.Rows, 4);
            Assert.AreEqual(v.GetValue(0), 1);
            Assert.AreEqual(v.GetValue(1), 2);
            Assert.AreEqual(v.GetValue(2), 3);
            Assert.AreEqual(v.GetValue(3), 4);
            try
            {
                v.GetValue(4);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                ;
            }
        }

        [TestMethod()]
        public void OneNormTest()
        {
            Vector v = new Vector(new double[] { 0, 0, 0 });
            Assert.AreEqual(v.OneNorm(), 0);

            v = new Vector(new double[] { 1, 0, 0 });
            Assert.AreEqual(v.OneNorm(), 1);

            v = new Vector(new double[] { 1, -1, 0 });
            Assert.AreEqual(v.OneNorm(), 2);

            v = new Vector(new double[] { 1, 2, 3 });
            Assert.AreEqual(v.OneNorm(), 6);
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            Vector v = new Vector(new double[] { 1, 0, 0 });
            v.Normalize();
            Assert.AreEqual(v.OneNorm(), 1);

            v = new Vector(new double[] { 1, 1, 0 });
            v.Normalize();
            Assert.AreEqual(v.OneNorm(), 1);

            v = new Vector(new double[] { 1, 1, 1 });
            v.Normalize();
            Assert.AreEqual(v.OneNorm(), 1);

            v = new Vector(new double[] { -1, 1, 1 });
            v.Normalize();
            Assert.AreEqual(v.OneNorm(), 1);
        }

        [TestMethod()]
        public void DivideByTest()
        {
            int i;
            Vector v = new Vector(new double[] { 1, 1, 1 });
            v.DivideBy(1);
            for (i = 0; i < v.Values.Length; i++)
                Assert.AreEqual(v.GetValue(i), 1);

            v.DivideBy(2);
            for (i = 0; i < v.Values.Length; i++)
                Assert.AreEqual(v.GetValue(i), 0.5);


        }
    }
}