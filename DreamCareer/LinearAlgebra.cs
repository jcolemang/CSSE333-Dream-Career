using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * I wanted to play with linear algebra and didn't
 * want to download a package or make my teammates
 * download a package. Apparently .NET doesn't have
 * a built in package that handles matrix multiplication.
 * Also I was curious how sparse matrices worked. 
 * Also again I really wanted to play with linear
 * algebra. Note that this is a minimal set of 
 * operations for PageRank; this is not a complete
 * linear algebra package. 
 * 
 */

namespace DreamCareer
{
    public class Vector
    {
        public int Rows { get; }
        public double[] Values;

        public Vector(int rows)
        {
            this.Rows = rows;
            this.Values = new double[rows];
        }

        public Vector(int rows, double[] StartValues)
        {
            this.Rows = rows;
            this.Values = new double[rows];
            int i;
            for (i = 0; i < rows; i++)
                this.Values[i] = StartValues[i];
        }

        public double GetValue(int row)
        {
            return this.Values[row];
        }

        public double OneNorm()
        {
            double sum = 0;
            int i;
            for (i = 0; i < this.Rows; i++)
                sum += this.Values[i];

            return sum;
        }

        public void Normalize()
        {
            this.DivideBy(this.OneNorm());
        }

        public void DivideBy(double val)
        {
            int i;
            for (i = 0; i < this.Rows; i++)
                this.Values[i] /= val;
        }
    }

    public class SparseMatrix
    {
        public int Rows { get; }
        public int Cols { get; }
        private Dictionary<int, Dictionary<int, double>> Values;

        public SparseMatrix(int rows, int cols)
        {
            this.Values = new Dictionary<int, Dictionary<int, double>>();
        }

        public void SetValue(int row, int col, double val)
        {
            if (row > this.Rows || row <= 0 || col >= this.Cols || col < 0)
                throw new FieldAccessException("Invalid row/column.");
            // doesn't contain any entries for that row
            if (!this.Values.ContainsKey(row))
                this.Values[row] = new Dictionary<int, double>();

            this.Values[row][col] = val;
        }

        public double GetValue(int row, int col)
        {
            if (row < 0 || row >= this.Rows || col < 0 || col >= this.Cols)
                throw new FieldAccessException("Row or column out of range.");

            if (this.ContainsValue(row, col))
                return this.Values[row][col];

            // Because of sparse assumption
            return 0;
        }

        public bool ContainsValue(int row, int col)
        {
            if (!this.Values.ContainsKey(row))
                return false;
            if (!this.Values[row].ContainsKey(col))
                return false;
            return true;
        }

        public void MultiplyByConstant(double constant)
        {
            foreach (int row in this.Values.Keys)
                foreach (int col in this.Values[row].Keys)
                    this.Values[row][col] /= constant;
        }

        public void AddConstant(double constant)
        {
            foreach (int row in this.Values.Keys)
                foreach (int col in this.Values[row].Keys)
                    this.Values[row][col] += constant;
        }

        public SparseMatrix Transpose()
        {
            SparseMatrix transposed = new SparseMatrix(this.Rows, this.Cols);
            foreach (int row in this.Values.Keys)
            {
                foreach (int col in this.Values[row].Keys)
                {
                    if (!transposed.Values.ContainsKey(col))
                        transposed.Values[col] = new Dictionary<int, double>();

                    transposed.Values[col][row] = this.Values[row][col];
                }
            }
            return transposed;
        }

        public Vector MultiplyOnRight(Vector vec)
        {
            Vector result = new Vector(this.Rows);

            double sum;
            foreach (int row in this.Values.Keys)
            {
                sum = 0;
                foreach (int col in this.Values[row].Keys)
                    sum += this.Values[row][col] * vec.Values[col];
                result.Values[row] = sum;
            }

            return result;
        }
    }


}