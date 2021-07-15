using System;
using static System.Math;

namespace SimulationInsight.MathLibrary
{
    public record Vector
    {
        public int NumberOfElements => Data.Length;

        public double[] Data { get; init; }

        public Vector()
        {
        }

        public Vector(int numberOfElements)
        {
            Data = new double[numberOfElements];
        }

        public Vector(int numberOfElements, double value)
        {
            Data = new double[numberOfElements];

            for (int i = 0; i < numberOfElements; i++)
            {
                Data[i] = value;
            }
        }

        public Vector(params double[] data)
        {
            Data = data;
        }

        public double this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public double GetCircularValue(int index)
        {
            var i = index % Data.Length;

            var x = Data[i];

            return x;
        }

        public static Vector LinearlySpacedVector(double start, double end, double step)
        {
            var span = end - start;

            int numberOfSamples = (int)(span / step);

            var result = new Vector(numberOfSamples);

            for (int i = 0; i < numberOfSamples; i++)
            {
                result[i] = start + step * i;
            }

            return result;
        }

        public static Vector operator +(Vector x, Vector y)
        {
            var data = new double[x.NumberOfElements];

            for (int i = 0; i < x.NumberOfElements; i++)
            {
                data[i] = x.Data[i] + y.Data[i];
            }

            var result = new Vector(data);

            return result;
        }

        public static Vector operator -(Vector x, Vector y)
        {
            var data = new double[x.NumberOfElements];

            for (int i = 0; i < x.NumberOfElements; i++)
            {
                data[i] = x.Data[i] - y.Data[i];
            }

            var result = new Vector(data);

            return result;
        }

        public static Vector operator *(Vector x, Vector y)
        {
            var data = new double[x.NumberOfElements];

            for (int i = 0; i < x.NumberOfElements; i++)
            {
                data[i] = x.Data[i] * y.Data[i];
            }

            var result = new Vector(data);

            return result;
        }

        public static Vector operator *(Vector x, double y)
        {
            var data = new double[x.NumberOfElements];

            for (int i = 0; i < x.NumberOfElements; i++)
            {
                data[i] = x.Data[i] * y;
            }

            var result = new Vector(data);

            return result;
        }

        public static Vector operator *(double x, Vector y)
        {
            var result = y * x;

            return result;
        }

        public static Vector operator /(Vector x, Vector y)
        {
            var data = new double[x.NumberOfElements];

            for (int i = 0; i < x.NumberOfElements; i++)
            {
                data[i] = x.Data[i] / y.Data[i];
            }

            var result = new Vector(data);

            return result;
        }

        public static Vector Cos(Vector x)
        {
            var data = new double[x.NumberOfElements];

            for (int i = 0; i < x.NumberOfElements; i++)
            {
                data[i] = Math.Cos(x.Data[i]);
            }

            var result = new Vector(data);

            return result;
        }

        public static Vector Sin(Vector x)
        {
            var data = new double[x.NumberOfElements];

            for (int i = 0; i < x.NumberOfElements; i++)
            {
                data[i] = Math.Sin(x.Data[i]);
            }

            var result = new Vector(data);

            return result;
        }
    }
}