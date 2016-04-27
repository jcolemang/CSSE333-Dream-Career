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
    public class SparseMatrixTests
    {
        [TestMethod()]
        public void SparseMatrixTest()
        {
            SparseMatrix M = new SparseMatrix(2, 2);
            Assert.AreEqual(M.Rows, 2);
            Assert.AreEqual(M.Cols, 2);
        }

        [TestMethod()]
        public void SetValueTest()
        {
            SparseMatrix M = new SparseMatrix(2, 2);
            M.SetValue(0, 0, 1);
            M.SetValue(0, 1, 2);
            M.SetValue(1, 0, 3);
            M.SetValue(1, 1, 4);
            Assert.AreEqual(M.GetValue(0, 0), 1);
            Assert.AreEqual(M.GetValue(0, 1), 2);
            Assert.AreEqual(M.GetValue(1, 0), 3);
            Assert.AreEqual(M.GetValue(1, 1), 4);

            try
            { 
                M.SetValue(2, 0, 7);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {

            }
            catch
            {
                Assert.Fail();
            }

            try
            { 
                M.SetValue(0, 2, 7);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {

            }
            catch
            {
                Assert.Fail();
            }

            try
            { 
                M.SetValue(0, -1, 7);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {

            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetValueTest()
        {
            SparseMatrix M = new SparseMatrix(2, 2);
            M.SetValue(0, 0, 1);
            Assert.AreEqual(M.GetValue(0, 0), 1);
        }

        [TestMethod()]
        public void ContainsEntryAtTest()
        {
            SparseMatrix M = new SparseMatrix(2, 2);
            M.SetValue(0, 0, 1);
            Assert.IsTrue(M.ContainsEntryAt(0, 0));
            Assert.IsFalse(M.ContainsEntryAt(0, 1));
            Assert.IsFalse(M.ContainsEntryAt(1, 0));
            Assert.IsFalse(M.ContainsEntryAt(1, 1));
        }

        [TestMethod()]
        public void MultiplyByConstantTest()
        {
            SparseMatrix M = new SparseMatrix(2, 2);
            M.SetValue(0, 0, 1);
            M.SetValue(0, 1, 2);
            M.SetValue(1, 0, 3);
            M.SetValue(1, 1, 4);
            M.MultiplyByConstant(2);
            double actual = M.GetValue(0, 0);
            Assert.AreEqual(actual, 2);
            Assert.AreEqual(M.GetValue(0, 1), 4);
            Assert.AreEqual(M.GetValue(1, 0), 6);
            Assert.AreEqual(M.GetValue(1, 1), 8);
            M.MultiplyByConstant(0.5);
            Assert.AreEqual(M.GetValue(0, 0), 1);
            Assert.AreEqual(M.GetValue(0, 1), 2);
            Assert.AreEqual(M.GetValue(1, 0), 3);
            Assert.AreEqual(M.GetValue(1, 1), 4);
        }


        [TestMethod()]
        public void MultiplyOnRightTest()
        {
            SparseMatrix M = new SparseMatrix(2, 2);
            M.SetValue(0, 0, 1);
            M.SetValue(1, 1, 1);
            Vector v = new Vector(new double[] { 1, 2 });
            Vector result = M.MultiplyOnRight(v);

            int i;
            for (i = 0; i < v.Rows; i++)
                Assert.AreEqual(v.GetValue(i), result.GetValue(i));

            M = new SparseMatrix(2, 2);
            M.SetValue(0, 0, 2);
            M.SetValue(1, 1, 2);
            v = new Vector(new double[] { 1, 2 });
            result = M.MultiplyOnRight(v);

            for (i = 0; i < v.Rows; i++)
                Assert.AreEqual(2*v.GetValue(i), result.GetValue(i));


            M = new SparseMatrix(2, 2);
            M.SetValue(0, 0, 1);
            M.SetValue(0, 1, 1);
            M.SetValue(1, 0, 1);
            M.SetValue(1, 1, 1);
            v = new Vector(new double[] { 1, 2 });
            result = M.MultiplyOnRight(v);

            for (i = 0; i < v.Rows; i++)
                Assert.AreEqual(3, result.GetValue(i));
        }
    }
}