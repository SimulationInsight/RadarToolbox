using System;

namespace SimulationInsight.MathLibrary
{
    public partial class Matrix
    {
        public int NumberOfRows => Data.GetLength(0);

        public int NumberOfColumns => Data.GetLength(1);

        public double[,] Data { get; set; }

        public double this[int rowIndex, int columnIndex]
        {
            get
            {
                return Data[rowIndex, columnIndex];
            }
            set
            {
                Data[rowIndex, columnIndex] = value;
            }
        }

        public Matrix this[int[] rowIndices, int[] columnIndices]
        {
            get
            {
                var result = new Matrix(rowIndices.Length, columnIndices.Length);

                for (int i = 0; i < rowIndices.Length; i++)
                {
                    for (int j = 0; j < columnIndices.Length; j++)
                    {
                        var ii = rowIndices[i];
                        var jj = columnIndices[j];

                        result[i, j] = Data[ii, jj];
                    }
                }
                return result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Matrix() : this(0, 0)
        {
        }

        public Matrix(int numberOfRows, int numberOfColumns)
        {
            Data = new double[numberOfRows, numberOfColumns];
        }

        public Matrix(double[,] data)
        {
            this.Data = data;
        }

        public Matrix Copy()
        {
            var result = new Matrix(NumberOfRows, NumberOfColumns);

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    result[i, j] = this[i, j];
                }
            }

            return result;
        }
    }
}