// <copyright file="SparseMatrixTest.cs">Copyright ©  2016</copyright>
using System;
using DreamCareer;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DreamCareer.Tests
{
    /// <summary>This class contains parameterized unit tests for SparseMatrix</summary>
    [PexClass(typeof(SparseMatrix))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SparseMatrixTest
    {
        /// <summary>Test stub for AddConstant(Double)</summary>
        [PexMethod]
        public void AddConstantTest([PexAssumeUnderTest]SparseMatrix target, double constant)
        {
            target.AddConstant(constant);
            // TODO: add assertions to method SparseMatrixTest.AddConstantTest(SparseMatrix, Double)
        }

        /// <summary>Test stub for .ctor(Int32, Int32)</summary>
        [PexMethod]
        public SparseMatrix ConstructorTest(int rows, int cols)
        {
            SparseMatrix target = new SparseMatrix(rows, cols);
            return target;
            // TODO: add assertions to method SparseMatrixTest.ConstructorTest(Int32, Int32)
        }

        /// <summary>Test stub for ContainsValue(Int32, Int32)</summary>
        [PexMethod]
        public bool ContainsValueTest(
            [PexAssumeUnderTest]SparseMatrix target,
            int row,
            int col
        )
        {
            bool result = target.ContainsValue(row, col);
            return result;
            // TODO: add assertions to method SparseMatrixTest.ContainsValueTest(SparseMatrix, Int32, Int32)
        }

        /// <summary>Test stub for GetValue(Int32, Int32)</summary>
        [PexMethod]
        public double GetValueTest(
            [PexAssumeUnderTest]SparseMatrix target,
            int row,
            int col
        )
        {
            double result = target.GetValue(row, col);
            return result;
            // TODO: add assertions to method SparseMatrixTest.GetValueTest(SparseMatrix, Int32, Int32)
        }

        /// <summary>Test stub for MultiplyByConstant(Double)</summary>
        [PexMethod]
        public void MultiplyByConstantTest([PexAssumeUnderTest]SparseMatrix target, double constant)
        {
            target.MultiplyByConstant(constant);
            // TODO: add assertions to method SparseMatrixTest.MultiplyByConstantTest(SparseMatrix, Double)
        }

        /// <summary>Test stub for MultiplyOnRight(Vector)</summary>
        [PexMethod]
        public Vector MultiplyOnRightTest([PexAssumeUnderTest]SparseMatrix target, Vector vec)
        {
            Vector result = target.MultiplyOnRight(vec);
            return result;
            // TODO: add assertions to method SparseMatrixTest.MultiplyOnRightTest(SparseMatrix, Vector)
        }

        /// <summary>Test stub for SetValue(Int32, Int32, Double)</summary>
        [PexMethod]
        public void SetValueTest(
            [PexAssumeUnderTest]SparseMatrix target,
            int row,
            int col,
            double val
        )
        {
            target.SetValue(row, col, val);
            // TODO: add assertions to method SparseMatrixTest.SetValueTest(SparseMatrix, Int32, Int32, Double)
        }

        /// <summary>Test stub for Transpose()</summary>
        [PexMethod]
        public SparseMatrix TransposeTest([PexAssumeUnderTest]SparseMatrix target)
        {
            SparseMatrix result = target.Transpose();
            return result;
            // TODO: add assertions to method SparseMatrixTest.TransposeTest(SparseMatrix)
        }
    }
}
